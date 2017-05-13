namespace AppQuanLyThuHocPhi.Data
{
    public class DbFactory :IDbFactory
    {
        private QLThuHocPhiDbContext dbContext;

        public void Dispose()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }

        public QLThuHocPhiDbContext Init()
        {
            return dbContext ?? (dbContext = new QLThuHocPhiDbContext());
        }

      
    }
}
