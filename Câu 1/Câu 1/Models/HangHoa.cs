using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Câu_1.Models;

[Table("HangHoa")]
public partial class HangHoa
{
    [Key]
    public int MaHang { get; set; }

    [Required]
    [StringLength(100)]
    public string TenHang { get; set; } = null!;

    [StringLength(50)]
    public string? LoaiHang { get; set; }

    [StringLength(20)]
    public string? DonVi { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal GiaBan { get; set; }

    public int SoLuongTon { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime NgayNhap { get; set; }

    public bool ConKinhDoanh { get; set; }
}
