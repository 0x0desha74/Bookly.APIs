using Bookly.APIs.Entities;
using System.ComponentModel.DataAnnotations;

namespace Bookly.APIs.DTOs
{
    public class BookDto
    {
       
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string PictureUrl { get; set; }
        [Required]
        public int TotalCopies { get; set; }
        [Required]
        public int AvailableCopies { get; set; }
        [Required]
        public ICollection<AuthorDto> Authors { get; set; } 
    }
}
