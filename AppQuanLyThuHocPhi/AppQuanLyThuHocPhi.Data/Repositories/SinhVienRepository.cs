using AppQuanLyThuHocPhi.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AppQuanLyThuHocPhi.Data.Repositories
{
    public interface ISinhVienRepository:IRepository<SinhVien>
    {
    }
    public class SinhVienRepository : Repository<SinhVien>, ISinhVienRepository
    {
        public SinhVienRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
