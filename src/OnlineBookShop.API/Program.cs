using Microsoft.AspNetCore.Builder;
using OnlineBookShop.API.Infrastructure.Extensions;
using System.Threading.Tasks;

namespace OnlineBookShop.API
{
    //When a new project will be created by default will be used top-level statements - programs without Main methods.
    //For better understanding where is entry point in application we deliberately keep Main
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var startup = new Startup(builder.Configuration);
            // Add services to the container.
            startup.AddServices(builder.Services);
            
            var webApplication = builder.Build();

            await webApplication.SeedData();

            // Configure the HTTP request pipeline.
            startup.Configure(webApplication, webApplication.Environment);

            await webApplication.RunAsync();
        }
    }
}
