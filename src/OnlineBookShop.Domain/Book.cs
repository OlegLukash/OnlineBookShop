using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBookShop.Domain
{
    public class Book : Entity<int>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime PublishedOn { get; set; }

        public string Publisher { get; set; }

        public decimal Price { get; set; }

        public virtual PriceOffer PriceOffer { get; set; }

        public virtual ICollection<AuthorBook> AuthorBooks { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public byte[] RowVersion { get; set; }

    }
}
