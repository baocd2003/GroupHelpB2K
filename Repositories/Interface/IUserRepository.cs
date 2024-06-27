using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IUserRepository
    {
        public void Add(User user);
        public void Update(User user);
        public void Delete(User user);
        public User? GetByEmail(string email);
        public User? GetById(int id);
        public User? Login(string email, string password);
        public (List<User> userList, int pageCount) GetAll(int page, int pageSize);
        public (List<User> userList, int paceCount) GetRole(UserRole userRole, int page, int pageSize);
    }
}
