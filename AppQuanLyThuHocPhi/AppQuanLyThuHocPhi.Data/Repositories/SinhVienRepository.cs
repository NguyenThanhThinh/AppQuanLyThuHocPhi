using AppQuanLyThuHocPhi.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AppQuanLyThuHocPhi.Data.Repositories
{
    public interface ISinhVienRepository
    {

    }
  
    public class SinhVienRepository : GenericRepository<SinhVien,string>, ISinhVienRepository
    {
        public SinhVienRepository(QLThuHocPhiDbContext db) : base(db)
        {
        }
    }
}
