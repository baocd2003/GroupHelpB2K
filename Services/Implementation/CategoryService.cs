using BusinessObjects;
using BusinessObjects.DTO;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _repository;

        public CategoryService(ICategoryRepo repository)
        {
            _repository = repository;
        }

        public void Add(Category category)
        {
            _repository.Add(category);
        }

        public void Delete(Category category)
        {
            _repository.Delete(category);
        }

        public List<Category> GetAll()
        {
            return _repository.GetAll();
        }

        public Category? GetById(int id)
        {
            return _repository.Get(id);
        }

        public void Update(Category category)
        {
            _repository.Update(category);
        }
    }
}
