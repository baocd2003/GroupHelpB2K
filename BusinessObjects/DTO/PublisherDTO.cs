using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO
{
    public class PublisherDTO
    {
        public int PublisherId { get; set; }
        [Required(ErrorMessage = "Publisher Name is required")]
        public string PublisherName { get; set; }
        [Required(ErrorMessage = "Publiser Description is required")] 
        public string PublisherDescription { get; set; }
    }
}
