using System;

namespace AppQuanLyThuHocPhi.Data
{
    public interface IDbFactory : IDisposable
    {
        QLThuHocPhiDbContext Init();
    }
}
