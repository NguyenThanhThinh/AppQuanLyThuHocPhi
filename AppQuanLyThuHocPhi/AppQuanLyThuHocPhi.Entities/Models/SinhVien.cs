using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppQuanLyThuHocPhi.Entities.Models
{
    [Table("SinhVien")]
    public  class SinhVien
    {
        [Key]
        [Column("MaSV", TypeName = "char")]
        [MaxLength(10)]
        public string MaSV { get; set; }
        public int MaLop { get; set; }
        [MaxLength(20)]
        public string HoSV { get; set; }
        [MaxLength(20)]
        public string TenSV { get; set; }
        public DateTime? NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        [MaxLength(120)]
        public string DiaChi { get; set; }
        [MaxLength(20)]
        public string DienThoai { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(20)]
        public string SoCMT { get; set; }
        public int MaMienGiam { get; set; }
        public virtual Lop Lop { get; set; }
        public virtual MienGiam MienGiam { get; set; }
        public virtual ICollection<PhieuThu> PhieuThus { get; set; }

    }
}
