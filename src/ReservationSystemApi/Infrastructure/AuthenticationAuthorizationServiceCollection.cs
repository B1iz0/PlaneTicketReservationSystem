using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PlaneTicketReservationSystem.Business.Constants;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Infrastructure
{
    public static class AuthenticationAuthorizationServiceCollection
    {
        public static IServiceCollection AddAuthenticationAuthorizationServices(this IServiceCollection services, IConfiguration configuration)
        {
            var tokenConfigurationSection = configuration.GetSection("AuthOptions");

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.RequireHttpsMetadata = false;
                    opt.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = tokenConfigurationSection["Issuer"],

                        ValidateAudience = true,
                        ValidAudience = tokenConfigurationSection["Audience"],

                        ValidateLifetime = true,

                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokenConfigurationSection["Key"])),
                        ValidateIssuerSigningKey = true,
                    };
                });
            services.AddAuthorization(opt =>
            {
                opt.AddPolicy(ApiRoles.AdminApp, policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireRole(ApiRoles.AdminApp);
                });
                opt.AddPolicy(ApiRoles.Admin, policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireRole(ApiRoles.Admin, ApiRoles.AdminApp);
                });
            });

            return services;
        }
    }
}
