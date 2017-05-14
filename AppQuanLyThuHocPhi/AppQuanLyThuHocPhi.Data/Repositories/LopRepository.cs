using AppQuanLyThuHocPhi.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AppQuanLyThuHocPhi.Data.Repositories
{
    public interface ILopRepository 
    {
        List<Lop> GetAllLop();
    }
    public class LopRepository : GenericRepository<Lop, int>, ILopRepository
    {
        public LopRepository(QLThuHocPhiDbContext db) : base(db)
        {
        }

        public List<Lop> GetAllLop()
        {
            return GetAll();
        }
    }
}
