using Bookly.APIs.Entities;

namespace Bookly.APIs.Specifications
{
    public class AuthorSpecifications : BaseSpecifications<Author>
    {
        public AuthorSpecifications(int id) : base(A => A.Id == id)
        {
            Includes.Add(A => A.Books);
        }
    }
}
