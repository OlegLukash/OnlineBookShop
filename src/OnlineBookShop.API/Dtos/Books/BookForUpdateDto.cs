using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineBookShop.API.Dtos.Books
{
    public class BookForUpdateDto
    {
        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string Title { get; set; }

        [StringLength(int.MaxValue, MinimumLength = 5)]
        public string Description { get; set; }

        [Required]
        public DateTime PublishedOn { get; set; }

        [Required]
        public int PublisherId { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
