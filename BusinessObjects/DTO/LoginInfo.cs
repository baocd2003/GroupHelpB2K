using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO
{
    public class LoginInfo
    {
        public LoginUserRole? Role { get; set; }
        public User? User { get; set; }
    }
}
