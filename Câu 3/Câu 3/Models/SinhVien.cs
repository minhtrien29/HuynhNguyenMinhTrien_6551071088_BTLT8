using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Câu_3.Models;

[Table("SinhVien")]
public partial class SinhVien
{
    [Key]
    [StringLength(10)]
    public string MaSV { get; set; } = null!;

    [Required]
    [StringLength(100)]
    public string HoTen { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime NgaySinh { get; set; }

    [Required]
    [StringLength(3)]
    public string GioiTinh { get; set; } = null!;

    [Required]
    [StringLength(10)]
    public string MaLop { get; set; } = null!;

    [ForeignKey(nameof(MaLop))]
    public virtual Lop Lop { get; set; } = null!;

    public virtual ICollection<DiemMon> DiemMons { get; set; } = new List<DiemMon>();
}
