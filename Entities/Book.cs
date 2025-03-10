﻿namespace Bookly.APIs.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public DateOnly PublishedDate { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }
        public ICollection<Author> Authors { get; set; } = new List<Author>();
       
  
    }
}
