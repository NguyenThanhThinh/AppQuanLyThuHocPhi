using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppQuanLyThuHocPhi.Entities.Models
{
    [Table("PhieuThu")]
    public  class PhieuThu
    {
        [Key]
        [Column("SOPHIEU", TypeName = "char")]
        [MaxLength(12)]
        public string SOPHIEU { get; set; }
        public string Id { get; set; }
        public string MaSV { get; set; }
        public int? HocPhi { get; set; }
        public int? MienGiam { get; set; }
        public int? ThucThu { get; set; }
        public DateTime? NgayThu { get; set; }
        [ForeignKey("LyDoThu")]
        public int MaLyDoThu { get; set; }

        public virtual LyDoThu LyDoThu { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        public virtual SinhVien SinhVien { get; set; }
    }
}
