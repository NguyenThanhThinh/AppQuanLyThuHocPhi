using AppQuanLyThuHocPhi.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppQuanLyThuHocPhi.Data
{
    public interface IUnitOfWork : IDisposable
    {
        QLThuHocPhiDbContext DbInstance { get; }
        ILopRepository LopRepo { get; }
      
        bool Commit();
    }
}
