using System;

namespace OnlineBookShop.API.Dtos.Books
{
    public class BookDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime PublishedOn { get; set; }

        public string Publisher { get; set; }

        public decimal Price { get; set; }
    }
}
