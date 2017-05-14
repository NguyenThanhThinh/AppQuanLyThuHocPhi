using AppQuanLyThuHocPhi.Entities.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace AppQuanLyThuHocPhi.Data
{
    public  class  QLThuHocPhiDbContext : DbContext
    {
        public QLThuHocPhiDbContext() : base("AppQLPetProject")
        {
            
        }
        public  DbSet<Lop> Lops { get; set; }
        public  DbSet<LyDoThu> LyDoThus { get; set; }
        public  DbSet<MienGiam> MienGiams { get; set; }
  
        public  DbSet<NhanVien> NhanViens { get; set; }
    
        public  DbSet<PhieuThu> PhieuThus { get; set; }
        public  DbSet<SinhVien> SinhViens { get; set; }
      
    }
}
