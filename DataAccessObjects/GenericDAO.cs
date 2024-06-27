using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessObjects
{
    public class GenericDAO<T> : IGenericDAO<T> where T : class
    {
        private readonly BookstoreDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public GenericDAO() 
        {
            _dbContext = new BookstoreDbContext();
            _dbSet = _dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
        }

        public T? GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public IGenericQueryable<T> Query()
        {
            return new GenericQueryable<T>(_dbSet.AsQueryable());
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
