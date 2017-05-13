using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppQuanLyThuHocPhi.Entities.Extensions
{
   public static partial class Extension
    {
        public static IQueryable<T> Including<T>(this IQueryable<T> self, params Expression<Func<T, object>>[] includeProperties) where T : class
        {
            return includeProperties.Aggregate(self, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
