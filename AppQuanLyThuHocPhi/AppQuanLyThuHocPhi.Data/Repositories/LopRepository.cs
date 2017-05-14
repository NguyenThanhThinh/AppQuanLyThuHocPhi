using AppQuanLyThuHocPhi.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AppQuanLyThuHocPhi.Data.Repositories
{
    public interface ILopRepository:IRepo<Lop,int>
    {
        List<Lop> GetAllLop();
    }
    public class LopRepository : Repo<Lop,int>, ILopRepository
    {
        public LopRepository(QLThuHocPhiDbContext db) : base(db)
        {
        }

        public List<Lop> GetAllLop()
        {
            return List();
        }
    }
}
