using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key] public int UserId { get; set; }
        [EmailAddress]
        [Required] public string Email { get; set; }
        [Required] public string Password { get; set; }
        [Required] public string UserName { get; set; }
        [Required] public AccountStatus AccountStatus { get; set; }
        [Required] public UserRole Role { get; set; }

        public virtual ICollection<Order>? Orders { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
    }
}
