using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppQuanLyThuHocPhi.Entities.Models
{
    [Table("MienGiam")]
    public class MienGiam
    {
        [Key]
        public int MaMienGiam { get; set; }
        [MaxLength(100)]
        public string TenMienGiam { get; set; }
        public int ? PhanTram { get; set; }

        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}
