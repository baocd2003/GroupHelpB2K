using BusinessObjects;
using BusinessObjects.DTO;
using Microsoft.Extensions.Configuration;
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
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public void Add(User user)
            => _repository.Add(user);

        public void Delete(User user)
            => _repository.Delete(user);

        public User? Get(int userId)
            => _repository.GetById(userId);

        public (List<User> userList, int pageCount) GetAll(int page, int pageSize)
            => _repository.GetAll(page, pageSize);

        public (List<User> userList, int pageCount) GetByRole(UserRole userRole, int page, int pageSize)
            => _repository.GetRole(userRole, page, pageSize);

        public bool IsEmailExisted(string email)
        {
            User? user = _repository.GetByEmail(email);
            return user != null;
        }

        public LoginInfo? Login(string email, string password)
        {
            var adminEmail = _configuration["AdminCredentials:Email"];
            var adminPassword = _configuration["AdminCredentials:Password"];
            if (email == adminEmail && password == adminPassword)
            {
                LoginInfo loginInfo = new()
                {
                    User = null,
                    Role = LoginUserRole.Admin,
                };
                return loginInfo;
            }

            var user = _repository.Login(email, password);
            if (user == null)
            {
                return null;
            }
            if (user.Role == UserRole.Customer)
            {
                LoginInfo loginInfo = new()
                {
                    User = user,
                    Role = LoginUserRole.Customer,
                };
                return loginInfo;
            }

            if (user.Role == UserRole.Staff)
            {
                LoginInfo loginInfo = new()
                {
                    User = user,
                    Role = LoginUserRole.Staff,
                };
                return loginInfo;
            }
            return null;
        }

        public void Update(User user)
            => _repository.Update(user);
    }
}
