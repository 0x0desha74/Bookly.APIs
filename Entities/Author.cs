namespace Bookly.APIs.Entities
{
    public class Author  : BaseEntity
    {
        public string Name { get; set; }
        public string Bio { get; set; }
        public DateOnly BirthDate { get; set; }
        public DateOnly? DeathDate { get; set; }
        public string Nationality { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
