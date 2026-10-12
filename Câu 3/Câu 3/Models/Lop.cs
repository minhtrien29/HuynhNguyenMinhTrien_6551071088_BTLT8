using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Câu_3.Models;

[Table("Lop")]
public partial class Lop
{
    [Key]
    [StringLength(10)]
    public string MaLop { get; set; } = null!;

    [Required]
    [StringLength(100)]
    public string TenLop { get; set; } = null!;

    public virtual ICollection<SinhVien> SinhViens { get; set; } = new List<SinhVien>();
}
