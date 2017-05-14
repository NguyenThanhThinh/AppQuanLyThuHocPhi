using AppQuanLyThuHocPhi.Entities.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppQuanLyThuHocPhi.Data.Repositories
{
    public class Repo<Entity,Key> : IRepo<Entity,Key> where Entity : class
    {
        protected QLThuHocPhiDbContext _db;
        protected DbSet<Entity> _table;
        protected bool _disposed = false;

        public IQueryable<Entity> All => _table.AsQueryable();

        public Repo() : this(new QLThuHocPhiDbContext())
        { }

        public Repo(QLThuHocPhiDbContext db)
        {
            _db = db;
            _table = db.Set<Entity>();
        }

       

        public Entity Create(Entity entity)
        {
            return _table.Add(entity);
        }

        public void Delete(Entity entity)
        {
            _table.Attach(entity);
            _table.Remove(entity);
        }

        public Entity GetById(Key id)
        {
            try
            {
                return _table.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public void Update(Entity entity)
        {
            _table.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

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

        public List<Entity> List(Expression<Func<Entity, bool>> where = null, Func<IQueryable<Entity>, IOrderedQueryable<Entity>> orderBy = null, params Expression<Func<Entity, object>>[] includes)
        {
            var all = All;

            if (includes != null && includes.Length > 0)
            {
                all = all.Including(includes);
            }

            if (where != null)
            {
                all = all.Where(where);
            }

            orderBy?.Invoke(all);

            return all.AsNoTracking().ToList();
        }
    }
}
