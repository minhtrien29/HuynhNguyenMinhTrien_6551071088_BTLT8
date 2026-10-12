using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastReport;
using FastReport.Export.Pdf;
using Microsoft.EntityFrameworkCore;
using Câu_2.Models;

namespace Câu_2
{
    public partial class Form1 : Form
    {
        private int? _selectedMaHD = null;
        private int? _selectedMaCT = null;
        private List<Mon> _danhSachMon = new();

        public Form1()
        {
            InitializeComponent();
            KhoiTaoDuLieuControl();
            DangKySuKien();
        }

        private void KhoiTaoDuLieuControl()
        {
            // Cài đặt khoảng thời gian tìm kiếm mặc định
            dtpTuNgay.Value = new DateTime(2026, 10, 1);
            dtpDenNgay.Value = new DateTime(2026, 10, 31);

            // Số bàn
            cboLocSoBan.Items.Add("Tất cả");
            cboSoBan.Items.Clear();
            for (int i = 1; i <= 10; i++)
            {
                cboLocSoBan.Items.Add(i.ToString());
                cboSoBan.Items.Add(i.ToString());
            }
            cboLocSoBan.SelectedIndex = 0;
            cboSoBan.SelectedIndex = 0;

            // Hình thức thanh toán lọc
            cboLocHinhThuc.Items.AddRange(new object[] { "Tất cả", "Tiền mặt", "Chuyển khoản" });
            cboLocHinhThuc.SelectedIndex = 0;

            dtpNgayLap.Value = DateTime.Now;

            dgvHoaDon.AutoGenerateColumns = false;
            dgvChiTiet.AutoGenerateColumns = false;
        }

        private void DangKySuKien()
        {
            Load += async (_, _) =>
            {
                await TaiDanhSachMonAsync();
                await LocHoaDonAsync();
            };

            btnTim.Click += async (_, _) => await LocHoaDonAsync();

            dgvHoaDon.CellClick += async (_, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    var hdItem = dgvHoaDon.Rows[e.RowIndex].DataBoundItem as HoaDonHienThi;
                    if (hdItem != null)
                    {
                        _selectedMaHD = hdItem.MaHD;
                        await HienThiChiTietHoaDonAsync(hdItem.MaHD);
                    }
                }
            };

            dgvChiTiet.CellClick += (_, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    var ctItem = dgvChiTiet.Rows[e.RowIndex].DataBoundItem as ChiTietHienThi;
                    if (ctItem != null)
                    {
                        _selectedMaCT = ctItem.MaCT;
                        numSoLuong.Value = Math.Max(1, Math.Min(50, ctItem.SoLuong));
                        // Chọn lại combo món
                        for (int i = 0; i < cboChonMon.Items.Count; i++)
                        {
                            if (cboChonMon.Items[i] is Mon m && m.MaMon == ctItem.MaMon)
                            {
                                cboChonMon.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }
            };

            btnHoaDonMoi.Click += async (_, _) => await XuLyHoaDonMoiAsync();
            btnSuaHoaDon.Click += async (_, _) => await XuLySuaHoaDonAsync();
            btnXoaHoaDon.Click += async (_, _) => await XuLyXoaHoaDonAsync();

            btnThemMon.Click += async (_, _) => await XuLyThemMonAsync();
            btnSuaSL.Click += async (_, _) => await XuLySuaSoLuongAsync();
            btnXoaMon.Click += async (_, _) => await XuLyXoaMonAsync();

            btnXemHoaDon.Click += async (_, _) => await XuLyXemHoaDonAsync();
            btnXuatPdf.Click += async (_, _) => await XuLyXuatPdfAsync();
            btnIn.Click += async (_, _) => await XuLyInHoaDonAsync();
        }

        private async Task TaiDanhSachMonAsync()
        {
            try
            {
                await using var db = new QuanCaPheDbContext();
                _danhSachMon = await db.Mons.OrderBy(m => m.MaMon).ToListAsync();

                cboChonMon.DataSource = null;
                cboChonMon.DisplayMember = "HienThi";
                cboChonMon.ValueMember = "MaMon";

                var listDisplay = _danhSachMon.Select(m => new
                {
                    m.MaMon,
                    HienThi = $"{m.TenMon} ({m.DonGia:N0} đ)"
                }).ToList();

                cboChonMon.DataSource = listDisplay;
                cboChonMon.DisplayMember = "HienThi";
                cboChonMon.ValueMember = "MaMon";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh mục món:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LocHoaDonAsync()
        {
            try
            {
                await using var db = new QuanCaPheDbContext();

                var query = db.HoaDons
                    .Include(h => h.ChiTietHoaDons)
                    .ThenInclude(ct => ct.Mon)
                    .AsQueryable();

                // Lọc theo khoảng ngày (tính từ 00:00:00 của TuNgay đến 23:59:59 của DenNgay)
                DateTime start = dtpTuNgay.Value.Date;
                DateTime end = dtpDenNgay.Value.Date.AddDays(1).AddTicks(-1);
                query = query.Where(h => h.NgayLap >= start && h.NgayLap <= end);

                // Lọc theo số bàn
                if (cboLocSoBan.SelectedIndex > 0 && int.TryParse(cboLocSoBan.SelectedItem?.ToString(), out int soBan))
                {
                    query = query.Where(h => h.SoBan == soBan);
                }

                // Lọc theo hình thức thanh toán
                string ht = cboLocHinhThuc.SelectedItem?.ToString() ?? "Tất cả";
                if (ht != "Tất cả")
                {
                    query = query.Where(h => h.HinhThucTT == ht);
                }

                // Lọc theo tên món
                string tenMon = txtLocTenMon.Text.Trim();
                if (!string.IsNullOrEmpty(tenMon))
                {
                    query = query.Where(h => h.ChiTietHoaDons.Any(ct => ct.Mon.TenMon.Contains(tenMon)));
                }

                var rawList = await query.OrderByDescending(h => h.NgayLap).ToListAsync();

                var hienThiList = rawList.Select(h => new HoaDonHienThi
                {
                    MaHD = h.MaHD,
                    NgayLap = h.NgayLap,
                    SoBan = h.SoBan,
                    HinhThucTT = h.HinhThucTT,
                    GhiChu = h.GhiChu,
                    TongTien = h.ChiTietHoaDons.Sum(ct => ct.SoLuong * ct.DonGia)
                }).ToList();

                dgvHoaDon.DataSource = hienThiList;

                decimal tongDoanhThu = hienThiList.Sum(h => h.TongTien);
                lblTongDoanhThu.Text = $"Tổng doanh thu đang hiển thị: {tongDoanhThu:N0} đ";

                // Nếu có hóa đơn được chọn trước đó, giữ lại hoặc chọn dòng đầu
                if (hienThiList.Count > 0)
                {
                    int index = 0;
                    if (_selectedMaHD.HasValue)
                    {
                        var found = hienThiList.FindIndex(h => h.MaHD == _selectedMaHD.Value);
                        if (found >= 0) index = found;
                    }

                    dgvHoaDon.ClearSelection();
                    dgvHoaDon.Rows[index].Selected = true;
                    _selectedMaHD = hienThiList[index].MaHD;
                    await HienThiChiTietHoaDonAsync(_selectedMaHD.Value);
                }
                else
                {
                    _selectedMaHD = null;
                    _selectedMaCT = null;
                    dgvChiTiet.DataSource = null;
                    lblChiTietTieuDe.Text = "Chi tiết hóa đơn";
                    lblTongCong.Text = "Tổng cộng: 0 đ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm hóa đơn:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task HienThiChiTietHoaDonAsync(int maHD)
        {
            try
            {
                await using var db = new QuanCaPheDbContext();
                var hd = await db.HoaDons
                    .Include(h => h.ChiTietHoaDons)
                    .ThenInclude(ct => ct.Mon)
                    .FirstOrDefaultAsync(h => h.MaHD == maHD);

                if (hd == null) return;

                lblChiTietTieuDe.Text = $"Chi tiết hóa đơn HD{hd.MaHD:D6}";
                dtpNgayLap.Value = hd.NgayLap;
                cboSoBan.SelectedItem = hd.SoBan.ToString();

                if (hd.HinhThucTT == "Tiền mặt")
                    rdoTienMat.Checked = true;
                else
                    rdoChuyenKhoan.Checked = true;

                txtGhiChu.Text = hd.GhiChu ?? "";

                int stt = 1;
                var ctList = hd.ChiTietHoaDons.OrderBy(ct => ct.MaCT).Select(ct => new ChiTietHienThi
                {
                    MaCT = ct.MaCT,
                    STT = stt++,
                    MaMon = ct.MaMon,
                    TenMon = ct.Mon?.TenMon ?? "",
                    SoLuong = ct.SoLuong,
                    DonGia = ct.DonGia
                }).ToList();

                dgvChiTiet.DataSource = ctList;

                decimal tongTien = ctList.Sum(ct => ct.ThanhTien);
                lblTongCong.Text = $"Tổng cộng: {tongTien:N0} đ";

                _selectedMaCT = ctList.FirstOrDefault()?.MaCT;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải chi tiết hóa đơn:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task XuLyHoaDonMoiAsync()
        {
            try
            {
                int soBan = int.Parse(cboSoBan.SelectedItem?.ToString() ?? "1");
                string httt = rdoTienMat.Checked ? "Tiền mặt" : "Chuyển khoản";

                var hdMoi = new HoaDon
                {
                    NgayLap = dtpNgayLap.Value,
                    SoBan = soBan,
                    HinhThucTT = httt,
                    GhiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text) ? null : txtGhiChu.Text.Trim()
                };

                await using var db = new QuanCaPheDbContext();
                db.HoaDons.Add(hdMoi);
                await db.SaveChangesAsync();

                _selectedMaHD = hdMoi.MaHD;
                MessageBox.Show($"Đã tạo hóa đơn mới HD{hdMoi.MaHD:D6}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LocHoaDonAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo hóa đơn:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task XuLySuaHoaDonAsync()
        {
            if (!_selectedMaHD.HasValue)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                await using var db = new QuanCaPheDbContext();
                var hd = await db.HoaDons.FindAsync(_selectedMaHD.Value);
                if (hd == null)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                hd.NgayLap = dtpNgayLap.Value;
                hd.SoBan = int.Parse(cboSoBan.SelectedItem?.ToString() ?? "1");
                hd.HinhThucTT = rdoTienMat.Checked ? "Tiền mặt" : "Chuyển khoản";
                hd.GhiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text) ? null : txtGhiChu.Text.Trim();

                await db.SaveChangesAsync();

                MessageBox.Show("Cập nhật hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LocHoaDonAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa hóa đơn:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task XuLyXoaHoaDonAsync()
        {
            if (!_selectedMaHD.HasValue)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa hóa đơn HD{_selectedMaHD.Value:D6}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                await using var db = new QuanCaPheDbContext();
                var hd = await db.HoaDons.Include(h => h.ChiTietHoaDons).FirstOrDefaultAsync(h => h.MaHD == _selectedMaHD.Value);
                if (hd != null)
                {
                    // Xóa các dòng chi tiết trước theo yêu cầu đề bài
                    db.ChiTietHoaDons.RemoveRange(hd.ChiTietHoaDons);
                    db.HoaDons.Remove(hd);
                    await db.SaveChangesAsync();
                }

                MessageBox.Show("Xóa hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _selectedMaHD = null;
                await LocHoaDonAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa hóa đơn:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task XuLyThemMonAsync()
        {
            if (!_selectedMaHD.HasValue)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn trước khi thêm món!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboChonMon.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn món cần thêm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maMon = (int)cboChonMon.SelectedValue;
            int soLuong = (int)numSoLuong.Value;

            try
            {
                await using var db = new QuanCaPheDbContext();
                var mon = await db.Mons.FindAsync(maMon);
                if (mon == null)
                {
                    MessageBox.Show("Không tìm thấy món!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra xem món đã có trong hóa đơn chưa
                var ct = await db.ChiTietHoaDons.FirstOrDefaultAsync(c => c.MaHD == _selectedMaHD.Value && c.MaMon == maMon);
                if (ct != null)
                {
                    ct.SoLuong += soLuong;
                }
                else
                {
                    ct = new ChiTietHoaDon
                    {
                        MaHD = _selectedMaHD.Value,
                        MaMon = maMon,
                        SoLuong = soLuong,
                        DonGia = mon.DonGia
                    };
                    db.ChiTietHoaDons.Add(ct);
                }

                await db.SaveChangesAsync();

                await HienThiChiTietHoaDonAsync(_selectedMaHD.Value);
                await CapNhatTongTienTrenLuoiTraiAsync(_selectedMaHD.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm món:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task XuLySuaSoLuongAsync()
        {
            if (!_selectedMaHD.HasValue || !_selectedMaCT.HasValue)
            {
                MessageBox.Show("Vui lòng chọn món trong lưới chi tiết cần sửa số lượng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soLuongMoi = (int)numSoLuong.Value;

            try
            {
                await using var db = new QuanCaPheDbContext();
                var ct = await db.ChiTietHoaDons.FindAsync(_selectedMaCT.Value);
                if (ct != null)
                {
                    ct.SoLuong = soLuongMoi;
                    await db.SaveChangesAsync();
                }

                await HienThiChiTietHoaDonAsync(_selectedMaHD.Value);
                await CapNhatTongTienTrenLuoiTraiAsync(_selectedMaHD.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa số lượng món:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task XuLyXoaMonAsync()
        {
            if (!_selectedMaHD.HasValue || !_selectedMaCT.HasValue)
            {
                MessageBox.Show("Vui lòng chọn món trong chi tiết cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                await using var db = new QuanCaPheDbContext();
                var ct = await db.ChiTietHoaDons.FindAsync(_selectedMaCT.Value);
                if (ct != null)
                {
                    db.ChiTietHoaDons.Remove(ct);
                    await db.SaveChangesAsync();
                }

                _selectedMaCT = null;
                await HienThiChiTietHoaDonAsync(_selectedMaHD.Value);
                await CapNhatTongTienTrenLuoiTraiAsync(_selectedMaHD.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa món:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CapNhatTongTienTrenLuoiTraiAsync(int maHD)
        {
            await using var db = new QuanCaPheDbContext();
            decimal tongMoi = await db.ChiTietHoaDons.Where(c => c.MaHD == maHD).SumAsync(c => c.SoLuong * c.DonGia);

            foreach (DataGridViewRow row in dgvHoaDon.Rows)
            {
                if (row.DataBoundItem is HoaDonHienThi item && item.MaHD == maHD)
                {
                    item.TongTien = tongMoi;
                    row.Cells[colTongTien.Index].Value = tongMoi;
                    break;
                }
            }

            // Cập nhật lại tổng doanh thu
            if (dgvHoaDon.DataSource is List<HoaDonHienThi> list)
            {
                decimal tongDoanhThu = list.Sum(h => h.TongTien);
                lblTongDoanhThu.Text = $"Tổng doanh thu đang hiển thị: {tongDoanhThu:N0} đ";
            }
        }

        private string TimDuongDanReport(string tenFile)
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var pathsToTry = new[]
            {
                Path.Combine(baseDir, "Reports", tenFile),
                Path.Combine(baseDir, "..", "..", "..", "Reports", tenFile),
                Path.Combine(baseDir, "..", "..", "..", "..", "Reports", tenFile)
            };

            foreach (var p in pathsToTry)
            {
                if (File.Exists(p)) return Path.GetFullPath(p);
            }

            return Path.Combine(baseDir, "Reports", tenFile);
        }

        private async Task<Report?> TaoReportHoaDonAsync()
        {
            if (!_selectedMaHD.HasValue)
            {
                MessageBox.Show("Chưa chọn hóa đơn để in hoặc xem trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            await using var db = new QuanCaPheDbContext();
            var hd = await db.HoaDons
                .Include(h => h.ChiTietHoaDons)
                .ThenInclude(ct => ct.Mon)
                .FirstOrDefaultAsync(h => h.MaHD == _selectedMaHD.Value);

            if (hd == null || hd.ChiTietHoaDons.Count == 0)
            {
                MessageBox.Show("Hóa đơn chưa có món nào! Không thể in trang trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            string duongDan = TimDuongDanReport("HoaDon.frx");
            if (!File.Exists(duongDan))
            {
                MessageBox.Show($"Không tìm thấy file mẫu report: {duongDan}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            int stt = 1;
            var dsChiTietIn = hd.ChiTietHoaDons.OrderBy(ct => ct.MaCT).Select(ct => new ChiTietIn
            {
                STT = stt++,
                TenMon = ct.Mon?.TenMon ?? "",
                SoLuong = ct.SoLuong,
                DonGia = ct.DonGia
            }).ToList();

            var report = new Report();
            report.Load(duongDan);
            report.RegisterData(dsChiTietIn, "ChiTiet");
            report.GetDataSource("ChiTiet").Enabled = true;

            // Truyền các tham số theo yêu cầu
            void SetParam(string name, string val)
            {
                var p = report.GetParameter(name);
                if (p != null) p.Value = val;
            }

            SetParam("TenQuan", "QUÁN CÀ PHÊ GÓC PHỐ");
            SetParam("SoHD", $"HD{hd.MaHD:D6}");
            SetParam("NgayLap", hd.NgayLap.ToString("dd/MM/yyyy HH:mm"));
            SetParam("SoBan", hd.SoBan.ToString());
            SetParam("HinhThucTT", hd.HinhThucTT);

            return report;
        }

        private async Task XuLyXemHoaDonAsync()
        {
            try
            {
                var report = await TaoReportHoaDonAsync();
                if (report == null) return;

                if (report.Prepare())
                {
                    report.ShowPrepared(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xem hóa đơn:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task XuLyXuatPdfAsync()
        {
            try
            {
                if (!_selectedMaHD.HasValue)
                {
                    MessageBox.Show("Vui lòng chọn hóa đơn cần xuất PDF!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string defaultName = $"HoaDon_HD{_selectedMaHD.Value:D6}.pdf";
                using var sfd = new SaveFileDialog
                {
                    Filter = "PDF Files (*.pdf)|*.pdf",
                    FileName = defaultName,
                    Title = "Xuất Hóa đơn ra file PDF"
                };

                if (sfd.ShowDialog() != DialogResult.OK) return;

                var report = await TaoReportHoaDonAsync();
                if (report == null) return;

                report.Prepare();
                var pdfExport = new PDFExport();
                report.Export(pdfExport, sfd.FileName);

                var hoiMo = MessageBox.Show("Xuất file PDF hóa đơn thành công! Bạn có muốn mở file ngay không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (hoiMo == DialogResult.Yes)
                {
                    Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                }
            }
            catch (IOException)
            {
                MessageBox.Show("File đang được mở bởi chương trình khác. Vui lòng đóng file và thử lại!", "Lỗi file", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất PDF:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task XuLyInHoaDonAsync()
        {
            try
            {
                var report = await TaoReportHoaDonAsync();
                if (report == null) return;

                report.Prepare();
                report.PrintSettings.ShowDialog = true;
                report.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi in hóa đơn:\n{ex.Message}", "Lỗi in", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
