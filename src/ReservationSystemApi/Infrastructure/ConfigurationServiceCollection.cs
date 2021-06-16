using Microsoft.Extensions.Configuration;
using PlaneTicketReservationSystem.Business.Helpers;
using PlaneTicketReservationSystem.ReservationSystemApi.Helpers;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigurationServiceCollection
    {
        public static IServiceCollection AddConfigurationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration.GetSection("AuthOptions"));
            services.Configure<AdminAppOptions>(configuration.GetSection("AdminAppOptions"));

            return services;
        }
    }
}
