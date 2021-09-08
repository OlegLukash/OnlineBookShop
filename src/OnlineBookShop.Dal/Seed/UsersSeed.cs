using Microsoft.AspNetCore.Identity;
using OnlineBookShop.Domain.Auth;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookShop.Dal.Seed
{
    public class UsersSeed
    {
        public static async Task Seed(UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new User()
                {
                    UserName = "admin",
                    Email = "admin@onlinebookshop.com",
                };

                await userManager.CreateAsync(user, "Qwerty1!");
            }
        }
    }
}
