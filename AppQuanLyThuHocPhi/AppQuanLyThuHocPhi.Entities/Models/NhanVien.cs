using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppQuanLyThuHocPhi.Entities.Models
{
    [Table("NhanVien")]
    public class NhanVien
    {
        [Key]
        [Column("MaNV", TypeName="char")]
        [MaxLength(10)]
        public string MaNV { get; set; }
        [MaxLength(20)]
        public string HoNV { get; set; }
        [MaxLength(20)]
        public string TenNV { get; set; }
        public DateTime? NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        [MaxLength(120)]
        public string DiaChi { get; set; }
        [MaxLength(20)]
        [Column("DienThoai", TypeName = "varchar")]
        public string DienThoai { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(50)]
        [Column("Matkhau", TypeName = "varchar")]
        public string Matkhau { get; set; }

        public virtual ICollection<PhieuThu> PhieuThus { get; set; }
    }
}
