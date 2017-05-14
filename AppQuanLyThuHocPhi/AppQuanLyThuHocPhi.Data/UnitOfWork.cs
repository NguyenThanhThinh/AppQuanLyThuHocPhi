using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppQuanLyThuHocPhi.Data.Repositories;
using Microsoft.Owin.Logging;
using NLog;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using AppQuanLyThuHocPhi.Entities.Extensions;

namespace AppQuanLyThuHocPhi.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Lazy<QLThuHocPhiDbContext> _db = null;
        private readonly Lazy<ILopRepository> _LopRepository = null;

        private static readonly NLog.ILogger _log = LogManager.GetCurrentClassLogger();
        public UnitOfWork()
        {
            _db = new Lazy<QLThuHocPhiDbContext>();
            _LopRepository = new Lazy<ILopRepository>(() => new LopRepository(_db.Value));
          
        }
        public QLThuHocPhiDbContext DbInstance => _db.Value;

      

        public ILopRepository LopRepo => _LopRepository.Value;

        public bool Commit()
        {
            try
            {
                _db.Value.SaveChanges();
                return true;
            }
            catch (DbEntityValidationException ex)
            {
                _log.Error($"Db Validation Exception: {ex.Message}. See detail below:");
                var detail = ex.EntityValidationErrors
                    .SelectMany(e => e.ValidationErrors)
                    .Select(e => $"Property: {e.PropertyName} -> {e.ErrorMessage}")
                    .ToSingle();

                _log.Error(detail);
            }
            catch (DbUpdateException ex)
            {
                _log.Error($"Db Update Exception: {ex.ToErrorMessage()}");
            }
            catch (Exception ex)
            {
                _log.Error($"Commit error: {ex.ToErrorMessage()}");
            }

            return false;
        }

        public void Dispose()
        {
            _db.Value.Dispose();
        }
    }
}
