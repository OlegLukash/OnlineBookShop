using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineBookShop.Domain;

namespace OnlineBookShop.Dal.EntityConfiguration
{
    public class AuthorBookConfig : IEntityTypeConfiguration<AuthorBook>
    {
        public void Configure(EntityTypeBuilder<AuthorBook> builder)
        {
            builder.ToTable("AuthorBooks");
            builder.HasKey(ab => new { ab.AuthorId, ab.BookId });

        }
    }
}
