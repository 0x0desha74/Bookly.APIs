namespace Bookly.APIs.DTOs
{
    public class AuthorDto
    {
        public string Name { get; set; }
        public string Bio { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public string Nationality { get; set; }
    }
}
