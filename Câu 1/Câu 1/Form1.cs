using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using FastReport;
using FastReport.Export.Pdf;
using Microsoft.EntityFrameworkCore;
using Câu_1.Models;

namespace Câu_1
{
    public partial class Form1 : Form
    {
        private int? _selectedMaHang = null;
        private List<HangHoa> _danhSachGoc = new();

        public Form1()
        {
            InitializeComponent();
            KhoiTaoDuLieuControl();
            DangKySuKien();
        }

        private void KhoiTaoDuLieuControl()
        {
            // Nạp dữ liệu các ComboBox
            cboLoaiHang.Items.AddRange(new object[] { "Đồ uống", "Thực phẩm khô", "Gia vị", "Đồ gia dụng" });
            cboLoaiHang.SelectedIndex = 0;

            cboDonVi.Items.AddRange(new object[] { "Chai", "Gói", "Hộp", "Túi" });
            cboDonVi.SelectedIndex = 0;

            cboLocLoaiHang.Items.AddRange(new object[] { "Tất cả", "Đồ uống", "Thực phẩm khô", "Gia vị", "Đồ gia dụng" });
            cboLocLoaiHang.SelectedIndex = 0;

            dgvHangHoa.AutoGenerateColumns = false;
            tmrTimKiem.Interval = 350;
        }

        private void DangKySuKien()
        {
            Load += async (_, _) => await TaiDuLieuAsync();

            dgvHangHoa.CellClick += (_, e) =>
            {
                if (e.RowIndex >= 0)
                    DoDuLieuLenControl(e.RowIndex);
            };

            btnThem.Click += async (_, _) => await XuLyThemAsync();
            btnSua.Click += async (_, _) => await XuLySuaAsync();
            btnXoa.Click += async (_, _) => await XuLyXoaAsync();
            btnLamMoi.Click += async (_, _) =>
            {
                LamMoiForm();
                await TaiDuLieuAsync();
            };

            // Tìm kiếm kết hợp
            txtTimKiem.TextChanged += (_, _) =>
            {
                tmrTimKiem.Stop();
                tmrTimKiem.Start();
            };

            tmrTimKiem.Tick += (_, _) =>
            {
                tmrTimKiem.Stop();
                LocDuLieu();
            };

            cboLocLoaiHang.SelectedIndexChanged += (_, _) => LocDuLieu();
            chkChiHienConKinhDoanh.CheckedChanged += (_, _) => LocDuLieu();

            // Report và Export
            btnXemBangGia.Click += async (_, _) => await XuLyXemBangGiaAsync();
            btnXuatPdf.Click += async (_, _) => await XuLyXuatPdfAsync();
            btnXuatExcelLuoi.Click += (_, _) => XuLyXuatExcelLuoi();
            btnXuatExcelTonKho.Click += async (_, _) => await XuLyXuatExcelTonKhoAsync();
        }

        private async Task TaiDuLieuAsync()
        {
            try
            {
                await using var db = new TiemTapHoaDbContext();
                _danhSachGoc = await db.HangHoas.OrderBy(h => h.MaHang).ToListAsync();
                LocDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu từ CSDL:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LocDuLieu()
        {
            var ketQua = _danhSachGoc.AsEnumerable();

            string tuKhoa = txtTimKiem.Text.Trim();
            if (!string.IsNullOrEmpty(tuKhoa))
            {
                ketQua = ketQua.Where(h => h.TenHang.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase));
            }

            string loai = cboLocLoaiHang.SelectedItem?.ToString() ?? "Tất cả";
            if (loai != "Tất cả")
            {
                ketQua = ketQua.Where(h => h.LoaiHang == loai);
            }

            if (chkChiHienConKinhDoanh.Checked)
            {
                ketQua = ketQua.Where(h => h.ConKinhDoanh);
            }

            var listHienThi = ketQua.ToList();
            dgvHangHoa.DataSource = listHienThi;
            lblTrangThai.Text = $"Tìm thấy {listHienThi.Count} mặt hàng";
        }

        private void DoDuLieuLenControl(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dgvHangHoa.Rows.Count) return;

            var row = dgvHangHoa.Rows[rowIndex];
            if (row.DataBoundItem is HangHoa hh)
            {
                _selectedMaHang = hh.MaHang;
                txtTenHang.Text = hh.TenHang;
                cboLoaiHang.SelectedItem = hh.LoaiHang;
                cboDonVi.SelectedItem = hh.DonVi;
                numGiaBan.Value = hh.GiaBan;
                numSoLuongTon.Value = hh.SoLuongTon;
                dtpNgayNhap.Value = hh.NgayNhap;
                chkConKinhDoanh.Checked = hh.ConKinhDoanh;
            }
        }

        private void LamMoiForm()
        {
            _selectedMaHang = null;
            txtTenHang.Clear();
            if (cboLoaiHang.Items.Count > 0) cboLoaiHang.SelectedIndex = 0;
            if (cboDonVi.Items.Count > 0) cboDonVi.SelectedIndex = 0;
            numGiaBan.Value = 0;
            numSoLuongTon.Value = 0;
            dtpNgayNhap.Value = DateTime.Now;
            chkConKinhDoanh.Checked = true;
            dgvHangHoa.ClearSelection();
        }

        private bool KiemTraHopLe()
        {
            if (string.IsNullOrWhiteSpace(txtTenHang.Text))
            {
                MessageBox.Show("Tên hàng không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenHang.Focus();
                return false;
            }

            if (numGiaBan.Value <= 0)
            {
                MessageBox.Show("Giá bán phải lớn hơn 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numGiaBan.Focus();
                return false;
            }

            return true;
        }

        private async Task XuLyThemAsync()
        {
            if (!KiemTraHopLe()) return;

            try
            {
                var hh = new HangHoa
                {
                    TenHang = txtTenHang.Text.Trim(),
                    LoaiHang = cboLoaiHang.SelectedItem?.ToString(),
                    DonVi = cboDonVi.SelectedItem?.ToString(),
                    GiaBan = numGiaBan.Value,
                    SoLuongTon = (int)numSoLuongTon.Value,
                    NgayNhap = dtpNgayNhap.Value,
                    ConKinhDoanh = chkConKinhDoanh.Checked
                };

                await using var db = new TiemTapHoaDbContext();
                db.HangHoas.Add(hh);
                await db.SaveChangesAsync();

                MessageBox.Show("Thêm hàng hóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiForm();
                await TaiDuLieuAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm hàng hóa:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task XuLySuaAsync()
        {
            if (_selectedMaHang == null)
            {
                MessageBox.Show("Vui lòng chọn hàng hóa cần sửa từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!KiemTraHopLe()) return;

            try
            {
                await using var db = new TiemTapHoaDbContext();
                var hh = await db.HangHoas.FindAsync(_selectedMaHang.Value);
                if (hh == null)
                {
                    MessageBox.Show("Hàng hóa không tồn tại hoặc đã bị xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                hh.TenHang = txtTenHang.Text.Trim();
                hh.LoaiHang = cboLoaiHang.SelectedItem?.ToString();
                hh.DonVi = cboDonVi.SelectedItem?.ToString();
                hh.GiaBan = numGiaBan.Value;
                hh.SoLuongTon = (int)numSoLuongTon.Value;
                hh.NgayNhap = dtpNgayNhap.Value;
                hh.ConKinhDoanh = chkConKinhDoanh.Checked;

                await db.SaveChangesAsync();

                MessageBox.Show("Cập nhật hàng hóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await TaiDuLieuAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa hàng hóa:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task XuLyXoaAsync()
        {
            if (_selectedMaHang == null)
            {
                MessageBox.Show("Vui lòng chọn hàng hóa cần xóa từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var xacNhan = MessageBox.Show("Bạn có chắc chắn muốn xóa hàng hóa này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (xacNhan != DialogResult.Yes) return;

            try
            {
                await using var db = new TiemTapHoaDbContext();
                var hh = await db.HangHoas.FindAsync(_selectedMaHang.Value);
                if (hh != null)
                {
                    db.HangHoas.Remove(hh);
                    await db.SaveChangesAsync();
                }

                MessageBox.Show("Xóa hàng hóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiForm();
                await TaiDuLieuAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa hàng hóa:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private async Task<Report?> TaoReportBangGiaAsync()
        {
            await using var db = new TiemTapHoaDbContext();
            var ds = await db.HangHoas.Where(h => h.ConKinhDoanh).OrderBy(h => h.MaHang).ToListAsync();

            var dt = new DataTable("HangHoa");
            dt.Columns.Add("MaHang", typeof(int));
            dt.Columns.Add("TenHang", typeof(string));
            dt.Columns.Add("LoaiHang", typeof(string));
            dt.Columns.Add("DonVi", typeof(string));
            dt.Columns.Add("GiaBan", typeof(decimal));
            dt.Columns.Add("SoLuongTon", typeof(int));
            dt.Columns.Add("NgayNhap", typeof(DateTime));
            dt.Columns.Add("ConKinhDoanh", typeof(bool));

            foreach (var item in ds)
            {
                dt.Rows.Add(item.MaHang, item.TenHang, item.LoaiHang, item.DonVi, item.GiaBan, item.SoLuongTon, item.NgayNhap, item.ConKinhDoanh);
            }

            string duongDan = TimDuongDanReport("BangGia.frx");
            if (!File.Exists(duongDan))
            {
                MessageBox.Show($"Không tìm thấy file mẫu report: {duongDan}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            var report = new Report();
            report.Load(duongDan);
            report.RegisterData(dt, "HangHoa");
            report.GetDataSource("HangHoa").Enabled = true;

            var pNgayIn = report.GetParameter("NgayIn");
            if (pNgayIn != null)
                pNgayIn.Value = DateTime.Now.ToString("dd/MM/yyyy");

            return report;
        }

        private async Task XuLyXemBangGiaAsync()
        {
            try
            {
                var report = await TaoReportBangGiaAsync();
                if (report == null) return;

                if (report.Prepare())
                {
                    report.ShowPrepared(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xem report:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task XuLyXuatPdfAsync()
        {
            try
            {
                using var sfd = new SaveFileDialog
                {
                    Filter = "PDF Files (*.pdf)|*.pdf",
                    FileName = "BangGia_UTC2.pdf",
                    Title = "Xuất Bảng giá ra file PDF"
                };

                if (sfd.ShowDialog() != DialogResult.OK) return;

                var report = await TaoReportBangGiaAsync();
                if (report == null) return;

                report.Prepare();
                var pdfExport = new PDFExport();
                report.Export(pdfExport, sfd.FileName);

                var hoiMo = MessageBox.Show("Xuất file PDF thành công! Bạn có muốn mở file ngay không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        private void XuLyXuatExcelLuoi()
        {
            try
            {
                if (dgvHangHoa.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu trên lưới để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using var sfd = new SaveFileDialog
                {
                    Filter = "Excel Files (*.xlsx)|*.xlsx",
                    FileName = "HangHoa_Luoi.xlsx",
                    Title = "Xuất dữ liệu lưới ra Excel"
                };

                if (sfd.ShowDialog() != DialogResult.OK) return;

                using var wb = new XLWorkbook();
                var ws = wb.Worksheets.Add("HangHoa");

                // Tiêu đề cột
                string[] headers = { "Mã", "Tên hàng", "Loại hàng", "Đơn vị", "Giá bán", "Tồn", "Ngày nhập", "Kinh doanh" };
                for (int c = 0; c < headers.Length; c++)
                {
                    ws.Cell(1, c + 1).Value = headers[c];
                }

                var hdrRange = ws.Range(1, 1, 1, headers.Length);
                hdrRange.Style.Font.Bold = true;
                hdrRange.Style.Fill.BackgroundColor = XLColor.LightGray;
                hdrRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                int rowIdx = 2;
                foreach (DataGridViewRow row in dgvHangHoa.Rows)
                {
                    if (row.IsNewRow) continue;

                    ws.Cell(rowIdx, 1).Value = Convert.ToInt32(row.Cells[colMaHang.Index].Value);
                    ws.Cell(rowIdx, 2).Value = row.Cells[colTenHang.Index].Value?.ToString() ?? "";
                    ws.Cell(rowIdx, 3).Value = row.Cells[colLoaiHang.Index].Value?.ToString() ?? "";
                    ws.Cell(rowIdx, 4).Value = row.Cells[colDonVi.Index].Value?.ToString() ?? "";
                    ws.Cell(rowIdx, 5).Value = Convert.ToDouble(row.Cells[colGiaBan.Index].Value ?? 0);
                    ws.Cell(rowIdx, 6).Value = Convert.ToInt32(row.Cells[colSoLuongTon.Index].Value ?? 0);

                    if (row.Cells[colNgayNhap.Index].Value is DateTime dt)
                        ws.Cell(rowIdx, 7).Value = dt;
                    else
                        ws.Cell(rowIdx, 7).Value = DateTime.Parse(row.Cells[colNgayNhap.Index].Value?.ToString() ?? DateTime.Now.ToString());

                    ws.Cell(rowIdx, 8).Value = Convert.ToBoolean(row.Cells[colConKinhDoanh.Index].Value ?? false);

                    rowIdx++;
                }

                int lastRow = rowIdx - 1;
                if (lastRow >= 2)
                {
                    ws.Range(2, 5, lastRow, 5).Style.NumberFormat.Format = "#,##0";
                    ws.Range(2, 6, lastRow, 6).Style.NumberFormat.Format = "#,##0";
                    ws.Range(2, 7, lastRow, 7).Style.NumberFormat.Format = "dd/MM/yyyy";
                    ws.Range(1, 1, lastRow, headers.Length).SetAutoFilter();
                }

                ws.SheetView.FreezeRows(1);
                ws.Columns().AdjustToContents();

                wb.SaveAs(sfd.FileName);

                var hoiMo = MessageBox.Show("Xuất file Excel thành công! Bạn có muốn mở file ngay không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                MessageBox.Show($"Lỗi khi xuất Excel lưới:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task XuLyXuatExcelTonKhoAsync()
        {
            try
            {
                using var sfd = new SaveFileDialog
                {
                    Filter = "Excel Files (*.xlsx)|*.xlsx",
                    FileName = "TonKho_UTC2.xlsx",
                    Title = "Xuất báo cáo tồn kho ra Excel"
                };

                if (sfd.ShowDialog() != DialogResult.OK) return;

                await using var db = new TiemTapHoaDbContext();
                var ds = await db.HangHoas.Where(h => h.ConKinhDoanh).OrderBy(h => h.MaHang).ToListAsync();

                using var wb = new XLWorkbook();
                var ws = wb.Worksheets.Add("TonKho");

                // Tiêu đề
                string[] headers = { "STT", "Mã hàng", "Tên hàng", "Loại hàng", "Đơn vị", "Giá bán", "Số lượng tồn", "Giá trị tồn" };
                for (int c = 0; c < headers.Length; c++)
                {
                    ws.Cell(1, c + 1).Value = headers[c];
                }

                var hdrRange = ws.Range(1, 1, 1, headers.Length);
                hdrRange.Style.Font.Bold = true;
                hdrRange.Style.Fill.BackgroundColor = XLColor.LightGray;
                hdrRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                int rowIdx = 2;
                int stt = 1;
                foreach (var hh in ds)
                {
                    ws.Cell(rowIdx, 1).Value = stt++;
                    ws.Cell(rowIdx, 2).Value = hh.MaHang;
                    ws.Cell(rowIdx, 3).Value = hh.TenHang;
                    ws.Cell(rowIdx, 4).Value = hh.LoaiHang ?? "";
                    ws.Cell(rowIdx, 5).Value = hh.DonVi ?? "";
                    ws.Cell(rowIdx, 6).Value = Convert.ToDouble(hh.GiaBan);
                    ws.Cell(rowIdx, 7).Value = hh.SoLuongTon;
                    // Công thức Giá trị tồn = Giá bán * Số lượng tồn (F{row} * G{row})
                    ws.Cell(rowIdx, 8).FormulaA1 = $"F{rowIdx}*G{rowIdx}";

                    rowIdx++;
                }

                int lastDataRow = rowIdx - 1;
                if (lastDataRow >= 2)
                {
                    ws.Range(2, 6, lastDataRow, 6).Style.NumberFormat.Format = "#,##0";
                    ws.Range(2, 7, lastDataRow, 7).Style.NumberFormat.Format = "#,##0";
                    ws.Range(2, 8, lastDataRow, 8).Style.NumberFormat.Format = "#,##0";

                    // Dòng Tổng cộng
                    int tongRow = rowIdx;
                    ws.Cell(tongRow, 1).Value = "Tổng";
                    ws.Range(tongRow, 1, tongRow, 7).Merge();
                    ws.Cell(tongRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                    ws.Cell(tongRow, 8).FormulaA1 = $"SUM(H2:H{lastDataRow})";
                    ws.Cell(tongRow, 8).Style.NumberFormat.Format = "#,##0";

                    var totalRowRange = ws.Range(tongRow, 1, tongRow, 8);
                    totalRowRange.Style.Font.Bold = true;

                    ws.Range(1, 1, lastDataRow, headers.Length).SetAutoFilter();
                }

                ws.SheetView.FreezeRows(1);
                ws.Columns().AdjustToContents();

                wb.SaveAs(sfd.FileName);

                var hoiMo = MessageBox.Show("Xuất file báo cáo tồn kho thành công! Bạn có muốn mở file ngay không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                MessageBox.Show($"Lỗi khi xuất Excel tồn kho:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
