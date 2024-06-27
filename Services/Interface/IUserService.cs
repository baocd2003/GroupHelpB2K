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
    public interface IUserService
    {
        public void Add(User user);
        public void Update(User user);
        public void Delete(User user);

        public LoginInfo? Login(string email, string password);
        public User? Get(int userId);
        public bool IsEmailExisted(string email);
        public (List<User> userList, int pageCount) GetAll(int page, int pageSize);
        public (List<User> userList, int pageCount) GetByRole(UserRole userRole, int page, int pageSize);

    }
}
