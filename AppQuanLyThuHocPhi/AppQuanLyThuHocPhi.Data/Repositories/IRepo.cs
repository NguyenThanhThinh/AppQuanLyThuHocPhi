using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppQuanLyThuHocPhi.Data.Repositories
{
    public interface IRepo<Entity,Key> : IDisposable where Entity : class
    {
        IQueryable<Entity> All { get; }
        /// <summary>
        /// get list of T entity with given condition and order.
        /// If includes has values, load related properties with eager loading
        /// </summary>
        /// <param name="where">the predicate to filter</param>
        /// <param name="orderBy">order result by order condition</param>
        /// <param name="includes">includes related properties to load</param>
        /// <returns>list of T entity</returns>
        List<Entity> List(Expression<Func<Entity, bool>> where = null, Func<IQueryable<Entity>, IOrderedQueryable<Entity>> orderBy = null, params Expression<Func<Entity, object>>[] includes);
        Entity GetById(Key id);
        Entity Create(Entity entity);
        void Update(Entity entity);
        void Delete(Entity entity);
    }
}
