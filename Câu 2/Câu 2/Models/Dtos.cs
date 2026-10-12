namespace Câu_2.Models;

public class ChiTietIn
{
    public int STT { get; set; }
    public string TenMon { get; set; } = string.Empty;
    public int SoLuong { get; set; }
    public decimal DonGia { get; set; }
    public decimal ThanhTien => SoLuong * DonGia;
}

public class HoaDonHienThi
{
    public int MaHD { get; set; }
    public string MaHDHienThi => $"HD{MaHD:D6}";
    public DateTime NgayLap { get; set; }
    public int SoBan { get; set; }
    public string HinhThucTT { get; set; } = string.Empty;
    public string? GhiChu { get; set; }
    public decimal TongTien { get; set; }
}

public class ChiTietHienThi
{
    public int MaCT { get; set; }
    public int STT { get; set; }
    public int MaMon { get; set; }
    public string TenMon { get; set; } = string.Empty;
    public int SoLuong { get; set; }
    public decimal DonGia { get; set; }
    public decimal ThanhTien => SoLuong * DonGia;
}
