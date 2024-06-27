using BusinessObjects;
using BusinessObjects.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface ICategoryService
    {
        public void Add(Category category);
        public void Update(Category category);
        public void Delete(Category category);
        public List<Category> GetAll();
        public Category? GetById(int id);
    }
}
