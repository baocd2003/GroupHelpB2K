using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [Required] public string Title { get; set; } = string.Empty;
        [Required] public string ImagePath { get; set; } = string.Empty;
        [Required] public string Author { get; set; } = string.Empty;
        [Required] public string Description { get; set; } = string.Empty;
        [Required] public DateTime PublishDate { get; set; }

        [Range(0, (double)decimal.MaxValue)]
        [Column(TypeName = "decimal(18, 2)")]
        [Required] public decimal Price { get; set; }

        [Required] [Range(0, int.MaxValue)] public int Quantity { get; set; }
        [Required] public bool IsAvailable { get; set; }

        [ForeignKey(nameof(Category))]
        [Required] public int CategoryId { get; set; }
        [ForeignKey(nameof(Publisher))]
        [Required] public int PublisherId { get; set; }

        public virtual Publisher? Publisher { get; set; }
        public virtual Category? Category { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}