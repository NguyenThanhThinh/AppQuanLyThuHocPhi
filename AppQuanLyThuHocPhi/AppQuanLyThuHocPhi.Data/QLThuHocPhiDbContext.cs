using AppQuanLyThuHocPhi.Entities.Models;
using System.Data.Entity;

namespace AppQuanLyThuHocPhi.Data
{
    public class QLThuHocPhiDbContext : DbContext
    {
        public QLThuHocPhiDbContext() : base("AppQLPetProject")
        {

        }
        public virtual DbSet<Lop> Lops { get; set; }
        public virtual DbSet<LyDoThu> LyDoThus { get; set; }
        public virtual DbSet<MienGiam> MienGiams { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhieuThu> PhieuThus { get; set; }
        public virtual DbSet<SinhVien> SinhViens { get; set; }
    }
}
