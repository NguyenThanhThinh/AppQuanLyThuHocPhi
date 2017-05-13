using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppQuanLyThuHocPhi.Data
{
    public class DbFactory : IDisposable,IDbFactory
    {
        private Lazy<QLThuHocPhiDbContext> dbContext;
        private bool disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    dbContext.Value?.Dispose();
                }

                disposed = true;
            }
        }

        public Lazy<QLThuHocPhiDbContext> Init()
        {
            return dbContext ?? (dbContext = new Lazy<QLThuHocPhiDbContext>());
        }

      
    }
}
