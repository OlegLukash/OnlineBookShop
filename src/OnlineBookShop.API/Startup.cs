using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineBookShop.API.Infrastructure.Extensions;
using OnlineBookShop.API.Repositories.Implementation;
using OnlineBookShop.API.Repositories.Interfaces;
using OnlineBookShop.Domain.Auth;
using System.Reflection;

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

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<OnlineBookShopDbContext>();

            var authOptions = services.ConfigureAuthOptions(Configuration);
            services.AddJwtAuthentication(authOptions);
            services.AddControllers();

            services.AddScoped<IRepository, EFCoreRepository>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
