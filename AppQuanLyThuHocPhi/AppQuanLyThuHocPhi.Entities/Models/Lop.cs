using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppQuanLyThuHocPhi.Entities.Models
{
    [Table("Lop")]
    public class Lop
    {
        [Key]
        public int MaLop { get; set; }
        [MaxLength(20)]
        public string TenLop { get; set; }
        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}
