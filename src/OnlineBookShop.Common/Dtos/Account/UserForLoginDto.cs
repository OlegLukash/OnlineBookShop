using System.ComponentModel.DataAnnotations;

namespace OnlineBookShop.Common.Dtos.Account
{
    public class UserForLoginDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
