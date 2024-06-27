﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public interface IGenericDAO<T> where T : class
    {
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public T? GetById(object id);
        public IGenericQueryable<T> Query();
    }
}
