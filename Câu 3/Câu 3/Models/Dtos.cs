using System;

namespace Câu_3.Models;

public class SinhVienHienThi
{
    public string MaSV { get; set; } = string.Empty;
    public string HoTen { get; set; } = string.Empty;
    public DateTime NgaySinh { get; set; }
    public string GioiTinh { get; set; } = string.Empty;
    public string MaLop { get; set; } = string.Empty;
}

public class DiemMonHienThi
{
    public int MaDiem { get; set; }
    public int STT { get; set; }
    public string TenMon { get; set; } = string.Empty;
    public int SoTinChi { get; set; }
    public decimal Diem { get; set; }
}
