using Bookly.APIs.Entities;

namespace Bookly.APIs.Specifications
{
    public class BookWithAuthorsSpecifications:BaseSpecifications<Book>
    {
        public BookWithAuthorsSpecifications(int id):base(b=>b.Id==id)
        {
            Includes.Add(b => b.Authors);
        }


        public BookWithAuthorsSpecifications()
        {
            Includes.Add(b => b.Authors);
        }
    }
}
