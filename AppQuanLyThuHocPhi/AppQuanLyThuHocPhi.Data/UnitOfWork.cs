using System;

namespace AppQuanLyThuHocPhi.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private Lazy<QLThuHocPhiDbContext> dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public Lazy<QLThuHocPhiDbContext> DbContext => dbContext ?? (dbContext = dbFactory.Init());
        public void Commit()
        {
            DbContext.Value.SaveChanges();
        }

      
    }
}
