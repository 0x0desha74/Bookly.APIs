using System.ComponentModel.DataAnnotations;

namespace Bookly.APIs.DTOs
{
    public class BookToReturnDto
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public string ISBN { get; set; }
        
        public string Genre { get; set; }
        
        public string Description { get; set; }
        
        public string PictureUrl { get; set; }
        
        public int TotalCopies { get; set; }
        
        public int AvailableCopies { get; set; }

        public ICollection<AuthorToReturnDto> Authors { get; set; }
    }
}
