using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using Câu_3.Models;

namespace Câu_3
{
    public class PhieuDiemPrinter
    {
        public PrintDocument Document { get; }

        public SinhVien? CurrentSinhVien { get; set; }
        public List<DiemMon> DanhSachDiem { get; set; } = new();
        public string TenLop { get; set; } = string.Empty;
        public decimal DiemTB { get; set; }
        public string XepLoai { get; set; } = string.Empty;

        private int _currentIndex = 0;
        private int _currentPage = 1;
        private int _totalPages = 1;

        public PhieuDiemPrinter()
        {
            Document = new PrintDocument();
            Document.BeginPrint += Document_BeginPrint;
            Document.PrintPage += Document_PrintPage;
        }

        private void Document_BeginPrint(object sender, PrintEventArgs e)
        {
            _currentIndex = 0;
            _currentPage = 1;

            // Tính ước lượng số trang
            int totalRows = DanhSachDiem.Count;
            // Mỗi trang in được khoảng 18 - 25 dòng tùy khổ giấy
            // Trang cuối cần chỗ trống cho điểm TB và chữ ký (~160px)
            _totalPages = Math.Max(1, (int)Math.Ceiling((totalRows + 6) / 22.0));
        }

        private void Document_PrintPage(object sender, PrintPageEventArgs e)
        {
            var g = e.Graphics;
            if (g == null) return;

            Rectangle bounds = e.MarginBounds;
            using var fontKhoa = new Font("Segoe UI", 10, FontStyle.Bold);
            using var fontTitle = new Font("Segoe UI", 16, FontStyle.Bold);
            using var fontSubBold = new Font("Segoe UI", 10, FontStyle.Bold);
            using var fontRegular = new Font("Segoe UI", 10, FontStyle.Regular);
            using var fontItalic = new Font("Segoe UI", 9.5f, FontStyle.Italic);
            using var pen = new Pen(Color.Black, 1f);

            int y = bounds.Top;

            // Header trang 1 (hoặc các trang)
            if (_currentPage == 1)
            {
                g.DrawString("KHOA CÔNG NGHỆ THÔNG TIN", fontKhoa, Brushes.Black, bounds.Left, y);
                y += 30;

                string tieuDe = "PHIẾU BÁO ĐIỂM";
                SizeF szTitle = g.MeasureString(tieuDe, fontTitle);
                g.DrawString(tieuDe, fontTitle, Brushes.Black, bounds.Left + (bounds.Width - szTitle.Width) / 2, y);
                y += 40;

                if (CurrentSinhVien != null)
                {
                    g.DrawString($"MSSV: {CurrentSinhVien.MaSV}", fontSubBold, Brushes.Black, bounds.Left, y);
                    y += 22;
                    g.DrawString($"Họ tên: {CurrentSinhVien.HoTen}", fontRegular, Brushes.Black, bounds.Left, y);
                    y += 22;
                    g.DrawString($"Ngày sinh: {CurrentSinhVien.NgaySinh:dd/MM/yyyy}", fontRegular, Brushes.Black, bounds.Left, y);
                    y += 22;
                    g.DrawString($"Lớp: {CurrentSinhVien.MaLop} - {TenLop}", fontRegular, Brushes.Black, bounds.Left, y);
                    y += 30;
                }
            }
            else
            {
                g.DrawString($"PHIẾU BÁO ĐIỂM (tiếp theo) - SV: {CurrentSinhVien?.HoTen} ({CurrentSinhVien?.MaSV})", fontSubBold, Brushes.Black, bounds.Left, y);
                y += 30;
            }

            // Kích thước các cột bảng điểm
            int wSTT = 50;
            int wTC = 70;
            int wDiem = 70;
            int wMon = bounds.Width - wSTT - wTC - wDiem;

            int xSTT = bounds.Left;
            int xMon = xSTT + wSTT;
            int xTC = xMon + wMon;
            int xDiem = xTC + wTC;

            int rowHeight = 26;

            // Vẽ tiêu đề bảng điểm
            g.FillRectangle(Brushes.LightGray, bounds.Left, y, bounds.Width, rowHeight);
            g.DrawRectangle(pen, bounds.Left, y, bounds.Width, rowHeight);
            g.DrawLine(pen, xMon, y, xMon, y + rowHeight);
            g.DrawLine(pen, xTC, y, xTC, y + rowHeight);
            g.DrawLine(pen, xDiem, y, xDiem, y + rowHeight);

            using var sfCenter = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            using var sfLeft = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center };
            using var sfRight = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center };

            g.DrawString("STT", fontSubBold, Brushes.Black, new RectangleF(xSTT, y, wSTT, rowHeight), sfCenter);
            g.DrawString("Môn học", fontSubBold, Brushes.Black, new RectangleF(xMon + 5, y, wMon - 5, rowHeight), sfLeft);
            g.DrawString("Số TC", fontSubBold, Brushes.Black, new RectangleF(xTC, y, wTC, rowHeight), sfCenter);
            g.DrawString("Điểm", fontSubBold, Brushes.Black, new RectangleF(xDiem, y, wDiem, rowHeight), sfCenter);
            y += rowHeight;

            // Chiều cao dự phòng cho phần tổng kết & chữ ký ở trang cuối
            int bottomMarginNeeded = 180;

            bool isLastPage = false;

            while (_currentIndex < DanhSachDiem.Count)
            {
                // Kiểm tra xem có đủ chỗ in dòng tiếp theo không
                bool canFitLastSummary = (y + rowHeight + bottomMarginNeeded <= bounds.Bottom);
                bool canFitNormalRow = (y + rowHeight + 40 <= bounds.Bottom);

                // Nếu còn 1 dòng cuối cùng và trang này đủ chỗ cho cả dòng lẫn phần tổng kết
                if (_currentIndex == DanhSachDiem.Count - 1 && !canFitLastSummary)
                {
                    // Chuyển dòng cuối cùng sang trang sau cùng với phần tổng kết
                    break;
                }

                if (!canFitNormalRow)
                {
                    break;
                }

                var item = DanhSachDiem[_currentIndex];
                g.DrawRectangle(pen, bounds.Left, y, bounds.Width, rowHeight);
                g.DrawLine(pen, xMon, y, xMon, y + rowHeight);
                g.DrawLine(pen, xTC, y, xTC, y + rowHeight);
                g.DrawLine(pen, xDiem, y, xDiem, y + rowHeight);

                g.DrawString((_currentIndex + 1).ToString(), fontRegular, Brushes.Black, new RectangleF(xSTT, y, wSTT, rowHeight), sfCenter);
                g.DrawString(item.TenMon, fontRegular, Brushes.Black, new RectangleF(xMon + 5, y, wMon - 5, rowHeight), sfLeft);
                g.DrawString(item.SoTinChi.ToString(), fontRegular, Brushes.Black, new RectangleF(xTC, y, wTC, rowHeight), sfCenter);
                g.DrawString(item.Diem.ToString("0.0"), fontRegular, Brushes.Black, new RectangleF(xDiem, y, wDiem, rowHeight), sfCenter);

                y += rowHeight;
                _currentIndex++;
            }

            if (_currentIndex >= DanhSachDiem.Count)
            {
                isLastPage = true;
            }

            if (isLastPage)
            {
                y += 15;
                string ketQuaDiem = (DanhSachDiem.Count > 0)
                    ? $"Điểm trung bình: {DiemTB:0.00} - Xếp loại: {XepLoai}"
                    : "Chưa có điểm";
                g.DrawString(ketQuaDiem, fontSubBold, Brushes.Black, bounds.Left, y);
                y += 35;

                // Hai chỗ ký tên
                int halfW = bounds.Width / 2;
                int xGiaoVu = bounds.Left;
                int xSinhVien = bounds.Left + halfW;

                g.DrawString("Giáo vụ khoa", fontSubBold, Brushes.Black, new RectangleF(xGiaoVu, y, halfW, 20), sfCenter);
                g.DrawString("(Ký, ghi rõ họ tên)", fontItalic, Brushes.Black, new RectangleF(xGiaoVu, y + 20, halfW, 20), sfCenter);

                g.DrawString("Sinh viên", fontSubBold, Brushes.Black, new RectangleF(xSinhVien, y, halfW, 20), sfCenter);
                g.DrawString("(Ký, ghi rõ họ tên)", fontItalic, Brushes.Black, new RectangleF(xSinhVien, y + 20, halfW, 20), sfCenter);
            }

            // Chân trang: Trang x/y
            string pageText = $"Trang {_currentPage}/{_totalPages}";
            g.DrawString(pageText, fontItalic, Brushes.Gray, new RectangleF(bounds.Left, bounds.Bottom - 20, bounds.Width, 20), sfCenter);

            if (_currentIndex < DanhSachDiem.Count)
            {
                _currentPage++;
                if (_currentPage > _totalPages) _totalPages = _currentPage;
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
        }
    }
}
