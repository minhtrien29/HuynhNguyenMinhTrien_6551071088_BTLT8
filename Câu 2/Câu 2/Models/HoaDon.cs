using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Câu_2.Models;

[Table("HoaDon")]
public partial class HoaDon
{
    [Key]
    public int MaHD { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime NgayLap { get; set; }

    public int SoBan { get; set; }

    [Required]
    [StringLength(20)]
    public string HinhThucTT { get; set; } = null!;

    [StringLength(200)]
    public string? GhiChu { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();
}
