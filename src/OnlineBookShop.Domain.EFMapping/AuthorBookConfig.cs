using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineBookShop.Domain.EFMapping
{
    public class AuthorBookConfig: IEntityTypeConfiguration<AuthorBook>
    {
        public void Configure(EntityTypeBuilder<AuthorBook> builder)
        {
            builder.ToTable("AuthorBooks");
            builder.HasKey(ab => new { ab.AuthorId, ab.BookId });

        }
    }
}
