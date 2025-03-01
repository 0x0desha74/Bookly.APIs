using Bookly.APIs.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Bookly.APIs.Data.Configurations
{
    public class BookConfigurations : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasMany(b => b.Authors)
             .WithMany(a => a.Books)
             .UsingEntity<Dictionary<string, object>>(
                 "BookAuthor",
                 j => j.HasOne<Author>().WithMany().HasForeignKey("AuthorId"),
                 j => j.HasOne<Book>().WithMany().HasForeignKey("BookId")
             );
        }
    }
}
