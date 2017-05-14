using AppQuanLyThuHocPhi.Entities.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppQuanLyThuHocPhi.Data.Repositories
{

    public interface IGenericRepository<TEntity, TKey> : IDisposable where TEntity : class
    {
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> where = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        TEntity GetById(TKey id);
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(TEntity entity);

        /// <summary>
        /// update entity with specify properties
        /// </summary>
        /// <param name="entity">the entity which need to update</param>
        /// <param name="updateProperties">properties in entity to update</param>
        /// <param name="isIgnore">if true, all updateProperties will be ignore</param>
        void Update(TEntity entity, List<Expression<Func<TEntity, object>>> updateProperties = null, bool isIgnore = false);

        /// <summary>
        /// return total deleted item
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        IEnumerable<TEntity> DeleteByCondition(Expression<Func<TEntity, bool>> where);

        /*
         * async version
         * 
         * */
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> where = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        Task<TEntity> GetByIdAsync(TKey id);
    }

    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : class
    {
        //protected static readonly NLog.ILogger _log = NLog.LogManager.GetCurrentClassLogger();
        protected QLThuHocPhiDbContext _db = null;
        protected DbSet<TEntity> _table = null;
        protected bool _disposed = false;

        public GenericRepository()
            : this(new QLThuHocPhiDbContext())
        {

        }

        public GenericRepository(QLThuHocPhiDbContext db)
        {
            _db = db;
            _table = _db.Set<TEntity>();


        }

        public TEntity Create(TEntity entity)
        {
            return _table.Add(entity);
        }

        public TEntity Delete(TEntity entity)
        {
            _table.Attach(entity);
            return _table.Remove(entity);
        }

        public IEnumerable<TEntity> DeleteByCondition(Expression<Func<TEntity, bool>> where)
        {
            var entities = Query(where);
            if (entities != null && entities.Any())
                return _table.RemoveRange(entities);

            return new List<TEntity>();
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> where = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            var entities = Query(where);
            if (orderBy != null)
                orderBy(entities);

            return entities.AsNoTracking().ToList();
        }

        public TEntity GetById(TKey id)
        {
            try
            {
                return _table.Find(id);
            }
            catch { }

            return default(TEntity);
        }

        public TEntity Update(TEntity entity)
        {
            _table.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        /// <summary>
        /// update entity with specify properties
        /// </summary>
        /// <param name="entity">the entity which need to update</param>
        /// <param name="updateProperties">properties in entity to update</param>
        /// <param name="isIgnore">if true, all updateProperties will be ignore</param>
        public void Update(TEntity entity, List<Expression<Func<TEntity, object>>> updateProperties = null, bool isIgnore = false)
        {
            _table.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
            if (updateProperties != null && updateProperties.Count > 0)
            {
                updateProperties.ForEach(p =>
                {
                    _db.Entry(entity).Property(p).IsModified = !isIgnore;
                });
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> where = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            var entities = Query(where);
            if (orderBy != null)
                orderBy(entities);

            return await entities.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            try
            {
                return await _table.FindAsync(id);
            }
            catch { }

            return default(TEntity);
        }


        #region helpers
        private IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> where)
        {
            if (where == null)
                return _table;

            return _table.Where(where);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                if (_db != null)
                {
                    _db.Dispose();
                    _db = null;
                }
            }

            _disposed = true;
        }
        #endregion

        private SqlParameter Param(string key, object value)
        {
            var s = value as string;
            if (s != null && string.IsNullOrEmpty(s))
                value = string.Empty;

            return new SqlParameter(key, value);
        }

        protected int ExecuteSqlCommand(string command, params object[] args) => _db.Database.ExecuteSqlCommand(command, args);
        protected List<TResult> SqlQuery<TResult>(string query, params object[] args) => _db.Database.SqlQuery<TResult>(query, args).ToList();

    }
}

    

