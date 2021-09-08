using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineBookShop.API.Infrastructure.Extensions;
using OnlineBookShop.API.Infrastructure.Middlewares;
using OnlineBookShop.Bll;
using OnlineBookShop.Bll.Interfaces;
using OnlineBookShop.Bll.Services;
using OnlineBookShop.Dal;
using OnlineBookShop.Dal.Interfaces;
using OnlineBookShop.Dal.Repositories;
using OnlineBookShop.Domain.Auth;

namespace OnlineBookShop.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<OnlineBookShopDbContext>(optionBuilder =>
            {
                optionBuilder.UseSqlServer(Configuration.GetConnectionString("OnlineBookShopConnection"));
            });

            services.AddIdentity<User, Role>(options => 
            {
                options.Password.RequiredLength = 8;
            })
            .AddEntityFrameworkStores<OnlineBookShopDbContext>();

            var authOptions = services.ConfigureAuthOptions(Configuration);
            services.AddJwtAuthentication(authOptions);
            services.AddControllers();

            services.AddScoped<IRepository, EFCoreRepository>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IPublisherService, PublisherService>();
            services.AddAutoMapper(typeof(BllAssemblyMarker));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseMiddleware<ErrorHandlingMiddleware>();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(configurePolicy => configurePolicy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
