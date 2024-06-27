using BusinessObjects;
using DataAccessObjects;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly IGenericDAO<User> _dao;

        public UserRepository(IGenericDAO<User> dao)
        {
            _dao = dao;
        }

        public void Add(User user)
            => _dao.Add(user);

        public void Delete(User user)
            => _dao.Delete(user);

        public (List<User> userList, int pageCount) GetAll(int page, int pageSize)
        {
            int currentPage = page < 1 ? 1 : page;
            int currentPageSize = pageSize < 1 ? 1 : pageSize;
            List<User> userList = _dao
                .Query()
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize)
                .ToList();
            int count = _dao.Query().Count();
            int pageCount = (int)Math.Ceiling((double)count / currentPageSize);
            return (userList, pageCount);
        }

        public User? GetByEmail(string email)
        {
            return _dao
                .Query()
                .Where(x => x.Email.Equals(email))
                .SingleOrDefault();
        }

        public User? GetById(int id)
            => _dao.GetById(id);

        public (List<User> userList, int paceCount) GetRole(UserRole userRole, int page, int pageSize)
        {
            int currentPage = page < 1 ? 1 : page;
            int currentPageSize = pageSize < 1 ? 1 : pageSize;
            List<User> userList = _dao
                .Query()
                .Where(x=>x.Role == userRole)
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize)
                .ToList();
            int count = _dao
                .Query()
                .Where(x => x.Role == userRole)
                .Count();
            int pageCount = (int)Math.Ceiling((double)count / currentPageSize);
            return (userList, pageCount);
        }

        public User? Login(string email, string password)
        {
            return _dao
                .Query()
                .Where(x => x.Email.Equals(email) && x.Password.Equals(password))
                .SingleOrDefault();
        }

        public void Update(User user)
            => _dao.Update(user);
    }
}
