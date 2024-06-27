using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO
{
    public class OrderDTO
    {
        [Required] 
        public int UserId { get; set; }
        [Range(0, (double)decimal.MaxValue)]
        [Column(TypeName = "decimal(18, 2)")]
        [Required] 
        public decimal TotalPrice { get; set; }
        [Required] 
        public DateTime OrderDate { get; set; }
        [Required] 
        public string DeliveryAddress { get; set; } = string.Empty;
        //thieu order note
        [Required] 
        public string PhoneNumber { get; set; }
        [Required] 
        public string OrderStatus { get; set; }
        [Required] 
        public string UserName { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public User User { get; set; }
    }
}
