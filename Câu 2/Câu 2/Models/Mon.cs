using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Câu_2.Models;

[Table("Mon")]
public partial class Mon
{
    [Key]
    public int MaMon { get; set; }

    [Required]
    [StringLength(100)]
    public string TenMon { get; set; } = null!;

    [StringLength(30)]
    public string? NhomMon { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal DonGia { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();
}
