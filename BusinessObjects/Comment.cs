using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace BusinessObjects
{
    public  class Comment
    {
        [ForeignKey(nameof(Book))]
        [Required]
        public int BookId { get; set; }
        [ForeignKey(nameof(User))]
        [Required]
        public int UserId { get; set; }
        [Required]
        public string CommentContent { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
        [Required]
        public CommentStatus CommentStatus { get; set; }

        public virtual Book? Book { get; set; }
        public virtual User? User { get; set; }
    }
}
