using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppQuanLyThuHocPhi.Entities.Models
{
    [Table("LyDoThu")]
    public class LyDoThu
    {
        [Key]
        public int MaLyDo { get; set; }
        [MaxLength(100)]
        public string TenLyDo { get; set; }

        public virtual ICollection<PhieuThu> PhieuThus { get; set; }
    }
}
