using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace OnlineBookShop.Domain.EFMapping
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.PublishedOn)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(x => x.Publisher)
                .IsRequired();

            builder.HasMany(x => x.Reviews)
                .WithOne(x => x.Book)
                .HasForeignKey(x => x.BookId);

            builder.Property(x => x.RowVersion)
                .IsRowVersion();
        }
    }
}
