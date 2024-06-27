using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class GenericQueryable<T> : IGenericQueryable<T>, IDisposable where T : class
    {
        private IQueryable<T> query;
        public GenericQueryable(IQueryable<T> query)
        {
            this.query = query;
        }

        public int Count()
        {
            int result = query.Count();
            this.Dispose();
            return result;
        }

        public void Dispose()
        {
            query = null;
            GC.SuppressFinalize(this);
        }

        public IGenericQueryable<T> Include(Expression<Func<T, object>> column)
        {
            query = query.Include(column);
            return this;
        }

        public IGenericQueryable<T> OrderBy(Expression<Func<T, object>> column)
        {
            query = query.OrderBy(column);
            return this;
        }

        public IGenericQueryable<T> OrderByDescending(Expression<Func<T, object>> column)
        {
            query = query.OrderByDescending(column);
            return this;
        }

        public T? SingleOrDefault()
        {
            T? result = query.SingleOrDefault();
            this.Dispose();
            return result;
        }

        public IGenericQueryable<T> Skip(int skip)
        {
            query = query.Skip(skip);
            return this;
        }

        public IGenericQueryable<T> Take(int take)
        {
            query = query.Take(take);
            return this;
        }

        public List<T> ToList()
        {
            List<T> result = query.ToList();
            this.Dispose();
            return result;
        }

        public IGenericQueryable<T> Where(Expression<Func<T, bool>> condition)
        {
            query = query.Where(condition);
            return this;
        }
    }
}
