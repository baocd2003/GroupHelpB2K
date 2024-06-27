using BusinessObjects;
using DataAccessObjects;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly IGenericDAO<Category> _dao;
        public CategoryRepo(IGenericDAO<Category> dao)
        {
            _dao = dao;
        }

        public void Add(Category category)
            => _dao.Add(category);

        public void Delete(Category category)
            => _dao.Delete(category);

        public Category? Get(int id)
            => _dao.GetById(id);

        public List<Category> GetAll()
            => _dao.Query().ToList();

        public void Update(Category category)
            => _dao.Update(category);
    }
}
