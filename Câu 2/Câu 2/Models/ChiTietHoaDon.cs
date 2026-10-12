using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Câu_2.Models;

[Table("ChiTietHoaDon")]
public partial class ChiTietHoaDon
{
    [Key]
    public int MaCT { get; set; }

    public int MaHD { get; set; }

    public int MaMon { get; set; }

    public int SoLuong { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal DonGia { get; set; }

    [ForeignKey(nameof(MaHD))]
    public virtual HoaDon HoaDon { get; set; } = null!;

    [ForeignKey(nameof(MaMon))]
    public virtual Mon Mon { get; set; } = null!;
}
