using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class OrderDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key] public int OrderDetailId { get; set; }
        [ForeignKey(nameof(Book))]
        [Required] public int BookId { get; set; }
        [ForeignKey(nameof(Order))]
        [Required] public int OrderId { get; set; }
        [Range(1, int.MaxValue)]
        [Required] public int Quantity { get; set; }
        [Range(1, (double)decimal.MaxValue)]
        [Column(TypeName = "decimal(18, 2)")]
        [Required] public decimal Price { get; set; }

        public virtual Book Book { get; set; }
        public virtual Order Order { get; set; }
    }
}
