using Bookly.APIs.Entities;

namespace Bookly.APIs.Specifications
{
    public class BookWithAuthorsSpecifications:BaseSpecifications<Book>
    {
        public BookWithAuthorsSpecifications(int id):base(b=>b.Id==id)
        {
            Includes.Add(b => b.Authors);
            Includes.Add(b => b.Genre);
        }


        public BookWithAuthorsSpecifications()
        {
            Includes.Add(b => b.Genre);
            Includes.Add(b => b.Genre);

        }
    }
}
