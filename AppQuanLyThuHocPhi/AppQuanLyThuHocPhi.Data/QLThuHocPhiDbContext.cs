using AppQuanLyThuHocPhi.Entities.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace AppQuanLyThuHocPhi.Data
{
    public  class  QLThuHocPhiDbContext : DbContext
    {
        public QLThuHocPhiDbContext() : base("AppQLPetProject")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public virtual DbSet<Lop> Lops { get; set; }
        public virtual DbSet<LyDoThu> LyDoThus { get; set; }
        public virtual DbSet<MienGiam> MienGiams { get; set; }
  
        public virtual DbSet<NhanVien> NhanViens { get; set; }
    
        public virtual DbSet<PhieuThu> PhieuThus { get; set; }
        public virtual DbSet<SinhVien> SinhViens { get; set; }
        public static QLThuHocPhiDbContext Create()
        {
            return new QLThuHocPhiDbContext();
        }
      
    }
}
