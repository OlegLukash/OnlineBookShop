using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBookShop.Domain
{
    public class PriceOffer : Entity<int>
    {
        public decimal NewPrice { get; set; }

        public string PromotionalText { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }
    }
}
