using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using OnlineBookShop.API.Configuration;
using Microsoft.Extensions.Configuration;

namespace OnlineBookShop.API.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddJwtAuthentication(this IServiceCollection services, AuthOptions authOptions)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = authOptions.Issuer,

                    ValidateAudience = true,
                    ValidAudience = authOptions.Audience,

                    ValidateLifetime = true,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = authOptions.GetSymmetricSecurityKey(),
                };
            });
        }

        public static AuthOptions ConfigureAuthOptions(this IServiceCollection services, IConfiguration configuration)
        {
            IConfigurationSection authOptionsConfigurationSection = configuration.GetSection("AuthOptions");
            services.Configure<AuthOptions>(authOptionsConfigurationSection);
            var authOptions = authOptionsConfigurationSection.Get<AuthOptions>();
            return authOptions;
        }
    }
}
