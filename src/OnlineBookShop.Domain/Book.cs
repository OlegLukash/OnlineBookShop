using System;
using System.Collections.Generic;

namespace OnlineBookShop.Domain
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime PublishedOn { get; set; }

        public decimal Price { get; set; }

        public int PublisherId { get; set; }

        public virtual Publisher Publisher { get; set; }

        public virtual PriceOffer PriceOffer { get; set; }

        public virtual ICollection<AuthorBook> AuthorBooks { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public byte[] RowVersion { get; set; }

    }
}
