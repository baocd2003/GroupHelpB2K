using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key] public int OrderId { get; set; }
        [ForeignKey(nameof(User))]
        [Required] public int UserId { get; set; }
        [Range(0, (double)decimal.MaxValue)]
        [Column(TypeName = "decimal(18, 2)")]
        [Required] public decimal TotalPrice { get; set; }
        [Required] public DateTime OrderDate { get; set; }
        [Required] public string DeliveryAddress { get; set; } = string.Empty;
        public string? Note { get; set; }
        [Required] public string PhoneNumber { get; set; }
        [Required] public OrderStatus OrderStatus { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual User User { get; set; }
    }
}
