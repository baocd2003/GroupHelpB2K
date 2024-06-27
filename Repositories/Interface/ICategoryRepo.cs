using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface ICategoryRepo
    {
        List<Category> GetAll();
        Category? Get(int id);
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
    }
}
