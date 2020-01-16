using Microsoft.EntityFrameworkCore;
using OnlineBookShop.Domain;
using OnlineBookShop.Domain.EFMapping;

namespace OnlineBookShop.API
{
    public class OnlineBookShopDbContext: DbContext
    {
        public OnlineBookShopDbContext(DbContextOptions<OnlineBookShopDbContext> options): base(options)
        {

        }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<PriceOffer> PriceOffers { get; set; }

        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var assembly = typeof(BookConfig).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }

    }
}
