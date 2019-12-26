namespace OnlineBookShop.Domain
{
    public class PriceOffer : BaseEntity
    {
        public decimal NewPrice { get; set; }

        public string PromotionalText { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }
    }
}
