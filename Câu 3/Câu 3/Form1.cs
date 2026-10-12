using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using Câu_3.Models;

namespace Câu_3
{
    public partial class Form1 : Form
    {
        private string? _selectedMaSV = null;
        private int? _selectedMaDiem = null;
        private List<SinhVien> _danhSachSV = new();
        private List<Lop> _danhSachLop = new();
        private readonly PhieuDiemPrinter _printer = new();

        public Form1()
        {
            InitializeComponent();
            KhoiTaoDuLieuControl();
            DangKySuKien();
        }

        private void KhoiTaoDuLieuControl()
        {
            dgvSinhVien.AutoGenerateColumns = false;
            dgvDiem.AutoGenerateColumns = false;
            dtpNgaySinh.Value = new DateTime(2005, 1, 1);
        }

        private void DangKySuKien()
        {
            Load += async (_, _) =>
            {
                await TaiDanhSachLopAsync();
                await TaiDanhSachSinhVienAsync();
            };

            lstLop.SelectedIndexChanged += (_, _) => LocSinhVien();
            txtTimKiem.TextChanged += (_, _) => LocSinhVien();

            dgvSinhVien.CellClick += async (_, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    var svItem = dgvSinhVien.Rows[e.RowIndex].DataBoundItem as SinhVienHienThi;
                    if (svItem != null)
                    {
                        _selectedMaSV = svItem.MaSV;
                        await HienThiThongTinSinhVienAsync(svItem.MaSV);
                    }
                }
            };

            dgvDiem.CellClick += (_, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    var dItem = dgvDiem.Rows[e.RowIndex].DataBoundItem as DiemMonHienThi;
                    if (dItem != null)
                    {
                        _selectedMaDiem = dItem.MaDiem;
                        txtTenMon.Text = dItem.TenMon;
                        numSoTinChi.Value = Math.Max(1, Math.Min(6, dItem.SoTinChi));
                        numDiem.Value = Math.Max(0, Math.Min(10, dItem.Diem));
                    }
                }
            };

            // Quản lý sinh viên
            btnThemSV.Click += async (_, _) => await XuLyThemSinhVienAsync();
            btnSuaSV.Click += async (_, _) => await XuLySuaSinhVienAsync();
            btnXoaSV.Click += async (_, _) => await XuLyXoaSinhVienAsync();

            // Quản lý điểm
            btnThemMon.Click += async (_, _) => await XuLyThemMonAsync();
            btnSuaDiem.Click += async (_, _) => await XuLySuaDiemAsync();
            btnXoaMon.Click += async (_, _) => await XuLyXoaMonAsync();

            // In và Xem trước
            btnXemTruocPhieu.Click += (_, _) => XuLyXemTruocPhieu();
            btnInPhieu.Click += (_, _) => XuLyInPhieu();
            btnCaiDatTrang.Click += (_, _) => XuLyCaiDatTrang();

            // Xuất Excel
            btnXuatExcelDiemLop.Click += async (_, _) => await XuLyXuatExcelDiemLopAsync();
        }

        private async Task TaiDanhSachLopAsync()
        {
            try
            {
                await using var db = new QuanLyDiemDbContext();
                _danhSachLop = await db.Lops.OrderBy(l => l.MaLop).ToListAsync();

                lstLop.Items.Clear();
                lstLop.Items.Add("Tất cả");
                foreach (var l in _danhSachLop)
                {
                    lstLop.Items.Add($"{l.MaLop} - {l.TenLop}");
                }
                lstLop.SelectedIndex = 0;

                cboLop.Items.Clear();
                foreach (var l in _danhSachLop)
                {
                    cboLop.Items.Add(l.MaLop);
                }
                if (cboLop.Items.Count > 0) cboLop.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách lớp:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task TaiDanhSachSinhVienAsync()
        {
            try
            {
                await using var db = new QuanLyDiemDbContext();
                _danhSachSV = await db.SinhViens.Include(s => s.Lop).OrderBy(s => s.MaSV).ToListAsync();
                LocSinhVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách sinh viên:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LocSinhVien()
        {
            var ketQua = _danhSachSV.AsEnumerable();

            // Lọc theo Lớp
            if (lstLop.SelectedIndex > 0 && lstLop.SelectedItem != null)
            {
                string sel = lstLop.SelectedItem.ToString() ?? "";
                string maLop = sel.Split('-')[0].Trim();
                ketQua = ketQua.Where(s => s.MaLop.Equals(maLop, StringComparison.OrdinalIgnoreCase));
            }

            // Lọc theo từ khóa
            string tuKhoa = txtTimKiem.Text.Trim();
            if (!string.IsNullOrEmpty(tuKhoa))
            {
                ketQua = ketQua.Where(s => s.MaSV.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase) ||
                                           s.HoTen.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase));
            }

            var listHienThi = ketQua.Select(s => new SinhVienHienThi
            {
                MaSV = s.MaSV,
                HoTen = s.HoTen,
                NgaySinh = s.NgaySinh,
                GioiTinh = s.GioiTinh,
                MaLop = s.MaLop
            }).ToList();

            dgvSinhVien.DataSource = listHienThi;

            if (listHienThi.Count > 0)
            {
                int index = 0;
                if (!string.IsNullOrEmpty(_selectedMaSV))
                {
                    var found = listHienThi.FindIndex(s => s.MaSV == _selectedMaSV);
                    if (found >= 0) index = found;
                }
                dgvSinhVien.ClearSelection();
                dgvSinhVien.Rows[index].Selected = true;
                _selectedMaSV = listHienThi[index].MaSV;
                _ = HienThiThongTinSinhVienAsync(_selectedMaSV);
            }
            else
            {
                _selectedMaSV = null;
                XoaTrangThongTinSV();
                dgvDiem.DataSource = null;
                CapNhatThongKeDiem(new List<DiemMon>());
            }
        }

        private async Task HienThiThongTinSinhVienAsync(string maSV)
        {
            try
            {
                await using var db = new QuanLyDiemDbContext();
                var sv = await db.SinhViens.Include(s => s.DiemMons).FirstOrDefaultAsync(s => s.MaSV == maSV);
                if (sv == null) return;

                txtMSSV.Text = sv.MaSV;
                txtHoTen.Text = sv.HoTen;
                dtpNgaySinh.Value = sv.NgaySinh;
                if (sv.GioiTinh == "Nữ")
                    rdoNu.Checked = true;
                else
                    rdoNam.Checked = true;

                cboLop.SelectedItem = sv.MaLop;

                // Tải danh sách điểm
                int stt = 1;
                var diemList = sv.DiemMons.OrderBy(d => d.MaDiem).ToList();

                var dgvList = diemList.Select(d => new DiemMonHienThi
                {
                    MaDiem = d.MaDiem,
                    STT = stt++,
                    TenMon = d.TenMon,
                    SoTinChi = d.SoTinChi,
                    Diem = d.Diem
                }).ToList();

                dgvDiem.DataSource = dgvList;

                CapNhatThongKeDiem(diemList);

                if (dgvList.Count > 0)
                {
                    _selectedMaDiem = dgvList[0].MaDiem;
                    txtTenMon.Text = dgvList[0].TenMon;
                    numSoTinChi.Value = dgvList[0].SoTinChi;
                    numDiem.Value = dgvList[0].Diem;
                }
                else
                {
                    _selectedMaDiem = null;
                    txtTenMon.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin sinh viên:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CapNhatThongKeDiem(List<DiemMon> dsDiem)
        {
            if (dsDiem == null || dsDiem.Count == 0)
            {
                lblTongTinChi.Text = "Tổng tín chỉ: 0";
                lblDiemTB.Text = "Điểm TB: Chưa có điểm";
                lblXepLoai.Text = "Xếp loại: -";
                return;
            }

            int tongTC = dsDiem.Sum(d => d.SoTinChi);
            decimal tongDiemWeighted = dsDiem.Sum(d => d.Diem * d.SoTinChi);
            decimal dtb = (tongTC > 0) ? Math.Round(tongDiemWeighted / tongTC, 2) : 0;

            string xepLoai = dtb switch
            {
                >= 8.0m => "Giỏi",
                >= 7.0m => "Khá",
                >= 5.0m => "Trung bình",
                _ => "Yếu"
            };

            lblTongTinChi.Text = $"Tổng tín chỉ: {tongTC}";
            lblDiemTB.Text = $"Điểm TB: {dtb:0.00}";
            lblXepLoai.Text = $"Xếp loại: {xepLoai}";
        }

        private void XoaTrangThongTinSV()
        {
            txtMSSV.Clear();
            txtHoTen.Clear();
            dtpNgaySinh.Value = new DateTime(2005, 1, 1);
            rdoNam.Checked = true;
            if (cboLop.Items.Count > 0) cboLop.SelectedIndex = 0;
            txtTenMon.Clear();
        }

        private async Task XuLyThemSinhVienAsync()
        {
            string mssv = txtMSSV.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string lop = cboLop.SelectedItem?.ToString() ?? "";

            if (string.IsNullOrWhiteSpace(mssv))
            {
                MessageBox.Show("MSSV không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMSSV.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show("Họ tên sinh viên không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            try
            {
                await using var db = new QuanLyDiemDbContext();
                bool exists = await db.SinhViens.AnyAsync(s => s.MaSV == mssv);
                if (exists)
                {
                    MessageBox.Show($"MSSV '{mssv}' đã tồn tại trong hệ thống! Vui lòng nhập mã khác.", "Cảnh báo trùng MSSV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMSSV.Focus();
                    return;
                }

                var sv = new SinhVien
                {
                    MaSV = mssv,
                    HoTen = hoTen,
                    NgaySinh = dtpNgaySinh.Value,
                    GioiTinh = rdoNam.Checked ? "Nam" : "Nữ",
                    MaLop = lop
                };

                db.SinhViens.Add(sv);
                await db.SaveChangesAsync();

                MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _selectedMaSV = mssv;
                await TaiDanhSachSinhVienAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm sinh viên:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task XuLySuaSinhVienAsync()
        {
            if (string.IsNullOrEmpty(_selectedMaSV))
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hoTen = txtHoTen.Text.Trim();
            string lop = cboLop.SelectedItem?.ToString() ?? "";

            if (string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show("Họ tên sinh viên không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            try
            {
                await using var db = new QuanLyDiemDbContext();
                var sv = await db.SinhViens.FindAsync(_selectedMaSV);
                if (sv == null)
                {
                    MessageBox.Show("Không tìm thấy sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                sv.HoTen = hoTen;
                sv.NgaySinh = dtpNgaySinh.Value;
                sv.GioiTinh = rdoNam.Checked ? "Nam" : "Nữ";
                sv.MaLop = lop;

                await db.SaveChangesAsync();

                MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await TaiDanhSachSinhVienAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa sinh viên:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task XuLyXoaSinhVienAsync()
        {
            if (string.IsNullOrEmpty(_selectedMaSV))
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa sinh viên {_selectedMaSV}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                await using var db = new QuanLyDiemDbContext();
                var sv = await db.SinhViens.Include(s => s.DiemMons).FirstOrDefaultAsync(s => s.MaSV == _selectedMaSV);
                if (sv != null)
                {
                    // Xóa các dòng điểm của sinh viên đó trước
                    db.DiemMons.RemoveRange(sv.DiemMons);
                    db.SinhViens.Remove(sv);
                    await db.SaveChangesAsync();
                }

                MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _selectedMaSV = null;
                await TaiDanhSachSinhVienAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa sinh viên:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task XuLyThemMonAsync()
        {
            if (string.IsNullOrEmpty(_selectedMaSV))
            {
                MessageBox.Show("Vui lòng chọn một sinh viên trước khi thêm điểm môn!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenMon = txtTenMon.Text.Trim();
            if (string.IsNullOrWhiteSpace(tenMon))
            {
                MessageBox.Show("Tên môn học không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenMon.Focus();
                return;
            }

            try
            {
                var dm = new DiemMon
                {
                    MaSV = _selectedMaSV,
                    TenMon = tenMon,
                    SoTinChi = (int)numSoTinChi.Value,
                    Diem = numDiem.Value
                };

                await using var db = new QuanLyDiemDbContext();
                db.DiemMons.Add(dm);
                await db.SaveChangesAsync();

                await HienThiThongTinSinhVienAsync(_selectedMaSV);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm điểm môn:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task XuLySuaDiemAsync()
        {
            if (string.IsNullOrEmpty(_selectedMaSV) || !_selectedMaDiem.HasValue)
            {
                MessageBox.Show("Vui lòng chọn môn học cần sửa điểm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenMon = txtTenMon.Text.Trim();
            if (string.IsNullOrWhiteSpace(tenMon))
            {
                MessageBox.Show("Tên môn học không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenMon.Focus();
                return;
            }

            try
            {
                await using var db = new QuanLyDiemDbContext();
                var dm = await db.DiemMons.FindAsync(_selectedMaDiem.Value);
                if (dm != null)
                {
                    dm.TenMon = tenMon;
                    dm.SoTinChi = (int)numSoTinChi.Value;
                    dm.Diem = numDiem.Value;
                    await db.SaveChangesAsync();
                }

                await HienThiThongTinSinhVienAsync(_selectedMaSV);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa điểm môn:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task XuLyXoaMonAsync()
        {
            if (string.IsNullOrEmpty(_selectedMaSV) || !_selectedMaDiem.HasValue)
            {
                MessageBox.Show("Vui lòng chọn môn học cần xóa khỏi bảng điểm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                await using var db = new QuanLyDiemDbContext();
                var dm = await db.DiemMons.FindAsync(_selectedMaDiem.Value);
                if (dm != null)
                {
                    db.DiemMons.Remove(dm);
                    await db.SaveChangesAsync();
                }

                _selectedMaDiem = null;
                await HienThiThongTinSinhVienAsync(_selectedMaSV);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa môn học:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ChuanBiIn(out SinhVien? sv, out List<DiemMon> dsDiem)
        {
            sv = null;
            dsDiem = new List<DiemMon>();

            if (string.IsNullOrEmpty(_selectedMaSV))
            {
                MessageBox.Show("Chưa chọn sinh viên để in phiếu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            using var db = new QuanLyDiemDbContext();
            sv = db.SinhViens.Include(s => s.Lop).Include(s => s.DiemMons).FirstOrDefault(s => s.MaSV == _selectedMaSV);
            if (sv == null || sv.DiemMons.Count == 0)
            {
                MessageBox.Show("Sinh viên chưa có điểm! Không thể in trang trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            dsDiem = sv.DiemMons.OrderBy(d => d.MaDiem).ToList();

            _printer.CurrentSinhVien = sv;
            _printer.DanhSachDiem = dsDiem;
            _printer.TenLop = sv.Lop?.TenLop ?? "";

            int tongTC = dsDiem.Sum(d => d.SoTinChi);
            decimal tongDiem = dsDiem.Sum(d => d.Diem * d.SoTinChi);
            decimal dtb = (tongTC > 0) ? Math.Round(tongDiem / tongTC, 2) : 0;
            _printer.DiemTB = dtb;
            _printer.XepLoai = dtb switch
            {
                >= 8.0m => "Giỏi",
                >= 7.0m => "Khá",
                >= 5.0m => "Trung bình",
                _ => "Yếu"
            };

            return true;
        }

        private void XuLyXemTruocPhieu()
        {
            try
            {
                if (!ChuanBiIn(out _, out _)) return;

                using var dlg = new PrintPreviewDialog
                {
                    Document = _printer.Document,
                    Width = 850,
                    Height = 650,
                    StartPosition = FormStartPosition.CenterScreen
                };
                dlg.ShowDialog(this);
            }
            catch (InvalidPrinterException)
            {
                MessageBox.Show("Không tìm thấy máy in hoặc dịch vụ in không hoạt động trên máy tính của bạn!", "Lỗi máy in", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xem trước phiếu điểm:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void XuLyInPhieu()
        {
            try
            {
                if (!ChuanBiIn(out _, out _)) return;

                using var dlg = new PrintDialog
                {
                    Document = _printer.Document,
                    UseEXDialog = true
                };

                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    _printer.Document.Print();
                }
            }
            catch (InvalidPrinterException)
            {
                MessageBox.Show("Không tìm thấy máy in hoặc dịch vụ in không hoạt động trên máy tính của bạn!", "Lỗi máy in", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi in phiếu điểm:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void XuLyCaiDatTrang()
        {
            try
            {
                using var dlg = new PageSetupDialog
                {
                    Document = _printer.Document
                };
                dlg.ShowDialog(this);
            }
            catch (InvalidPrinterException)
            {
                MessageBox.Show("Không tìm thấy máy in hoặc dịch vụ in không hoạt động trên máy tính của bạn!", "Lỗi máy in", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cài đặt trang:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task XuLyXuatExcelDiemLopAsync()
        {
            try
            {
                // Xác định lớp cần xuất
                string maLop = "";
                if (lstLop.SelectedIndex > 0 && lstLop.SelectedItem != null)
                {
                    maLop = lstLop.SelectedItem.ToString()!.Split('-')[0].Trim();
                }
                else if (!string.IsNullOrEmpty(_selectedMaSV))
                {
                    var sv = _danhSachSV.FirstOrDefault(s => s.MaSV == _selectedMaSV);
                    if (sv != null) maLop = sv.MaLop;
                }
                else if (_danhSachLop.Count > 0)
                {
                    maLop = _danhSachLop[0].MaLop;
                }

                if (string.IsNullOrEmpty(maLop))
                {
                    MessageBox.Show("Vui lòng chọn một lớp để xuất điểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using var sfd = new SaveFileDialog
                {
                    Filter = "Excel Files (*.xlsx)|*.xlsx",
                    FileName = $"BangDiem_{maLop}.xlsx",
                    Title = $"Xuất bảng điểm lớp {maLop} ra Excel"
                };

                if (sfd.ShowDialog() != DialogResult.OK) return;

                await using var db = new QuanLyDiemDbContext();
                // Truy vấn nối 3 bảng bằng EF Core
                var dsDiemLop = await (from sv in db.SinhViens
                                       join lp in db.Lops on sv.MaLop equals lp.MaLop
                                       join dm in db.DiemMons on sv.MaSV equals dm.MaSV
                                       where sv.MaLop == maLop
                                       orderby sv.MaSV, dm.MaDiem
                                       select new
                                       {
                                           sv.MaSV,
                                           sv.HoTen,
                                           Lop = lp.MaLop,
                                           dm.TenMon,
                                           dm.SoTinChi,
                                           dm.Diem
                                       }).ToListAsync();

                if (dsDiemLop.Count == 0)
                {
                    MessageBox.Show($"Lớp {maLop} chưa có dữ liệu điểm nào để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using var wb = new XLWorkbook();
                var ws = wb.Worksheets.Add($"Diem_{maLop}");

                // Tiêu đề cột: MSSV, Họ tên, Lớp, Môn học, Số TC, Điểm
                string[] headers = { "MSSV", "Họ tên", "Lớp", "Môn học", "Số TC", "Điểm" };
                for (int c = 0; c < headers.Length; c++)
                {
                    ws.Cell(1, c + 1).Value = headers[c];
                }

                var hdr = ws.Range(1, 1, 1, headers.Length);
                hdr.Style.Font.Bold = true;
                hdr.Style.Fill.BackgroundColor = XLColor.LightGray;
                hdr.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                int rowIdx = 2;
                foreach (var d in dsDiemLop)
                {
                    ws.Cell(rowIdx, 1).Value = d.MaSV;
                    ws.Cell(rowIdx, 2).Value = d.HoTen;
                    ws.Cell(rowIdx, 3).Value = d.Lop;
                    ws.Cell(rowIdx, 4).Value = d.TenMon;
                    ws.Cell(rowIdx, 5).Value = d.SoTinChi;
                    ws.Cell(rowIdx, 6).Value = Convert.ToDouble(d.Diem);
                    rowIdx++;
                }

                int lastDataRow = rowIdx - 1;

                // Định dạng số
                ws.Range(2, 5, lastDataRow, 5).Style.NumberFormat.Format = "0";
                ws.Range(2, 6, lastDataRow, 6).Style.NumberFormat.Format = "0.00";

                // Hai dòng công thức cuối bảng theo yêu cầu:
                // Dòng Tổng số tín chỉ dùng SUM cột Số TC (cột E)
                int rowTongTC = rowIdx;
                ws.Cell(rowTongTC, 1).Value = "Tổng số tín chỉ";
                ws.Range(rowTongTC, 1, rowTongTC, 4).Merge();
                ws.Cell(rowTongTC, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                ws.Cell(rowTongTC, 5).FormulaA1 = $"SUM(E2:E{lastDataRow})";
                ws.Cell(rowTongTC, 5).Style.NumberFormat.Format = "0";
                ws.Range(rowTongTC, 1, rowTongTC, 6).Style.Font.Bold = true;

                // Dòng Điểm trung bình dùng AVERAGE cột Điểm (cột F)
                int rowDiemTB = rowIdx + 1;
                ws.Cell(rowDiemTB, 1).Value = "Điểm trung bình";
                ws.Range(rowDiemTB, 1, rowDiemTB, 5).Merge();
                ws.Cell(rowDiemTB, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                ws.Cell(rowDiemTB, 6).FormulaA1 = $"AVERAGE(F2:F{lastDataRow})";
                ws.Cell(rowDiemTB, 6).Style.NumberFormat.Format = "0.00";
                ws.Range(rowDiemTB, 1, rowDiemTB, 6).Style.Font.Bold = true;

                ws.Range(1, 1, lastDataRow, headers.Length).SetAutoFilter();
                ws.SheetView.FreezeRows(1);
                ws.Columns().AdjustToContents();

                wb.SaveAs(sfd.FileName);

                var hoiMo = MessageBox.Show($"Xuất bảng điểm lớp {maLop} thành công! Bạn có muốn mở file ngay không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                MessageBox.Show($"Lỗi khi xuất Excel bảng điểm lớp:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
