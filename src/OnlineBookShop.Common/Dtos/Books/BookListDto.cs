using System;

namespace OnlineBookShop.Common.Dtos.Books
{
    public class BookListDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime PublishedOn { get; set; }

        public string Publisher { get; set; }

        public decimal Price { get; set; }
    }
}
