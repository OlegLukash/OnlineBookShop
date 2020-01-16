﻿using System;

namespace OnlineBookShop.API.Dtos.Books
{
    public class BookForUpdateDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime PublishedOn { get; set; }

        public int PublisherId { get; set; }

        public decimal Price { get; set; }
    }
}
