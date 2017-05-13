using System;

namespace AppQuanLyThuHocPhi.Data
{
    public interface IDbFactory : IDisposable
    {
        Lazy<QLThuHocPhiDbContext> Init();
    }
}
