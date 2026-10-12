using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Câu_3.Models;

[Table("DiemMon")]
public partial class DiemMon
{
    [Key]
    public int MaDiem { get; set; }

    [Required]
    [StringLength(10)]
    public string MaSV { get; set; } = null!;

    [Required]
    [StringLength(100)]
    public string TenMon { get; set; } = null!;

    public int SoTinChi { get; set; }

    [Column(TypeName = "decimal(4, 2)")]
    public decimal Diem { get; set; }

    [ForeignKey(nameof(MaSV))]
    public virtual SinhVien SinhVien { get; set; } = null!;
}
