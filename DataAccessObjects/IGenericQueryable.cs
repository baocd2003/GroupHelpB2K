using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public interface IGenericQueryable<T> where T : class
    {
        IGenericQueryable<T> Where(Expression<Func<T, bool>> condition);
        IGenericQueryable<T> Include(Expression<Func<T, object>> column);
        IGenericQueryable<T> OrderBy(Expression<Func<T, object>> column);
        IGenericQueryable<T> OrderByDescending(Expression<Func<T, object>> column);
        IGenericQueryable<T> Skip(int skip);
        IGenericQueryable<T> Take(int take);
        List<T> ToList();
        int Count();
        T? SingleOrDefault();
    }
}
