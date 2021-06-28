using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlaneTicketReservationSystem.Business.Helpers;
using PlaneTicketReservationSystem.ReservationSystemApi.Helpers;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Infrastructure
{
    public static class ConfigurationServiceCollection
    {
        public static IServiceCollection AddConfigurationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<TokenSettings>(configuration.GetSection("AuthOptions"));
            services.Configure<AdminAppOptions>(configuration.GetSection("AdminAppOptions"));
            services.Configure<PasswordServiceSettings>(configuration.GetSection("PasswordSalt"));

            return services;
        }
    }
}
