using Microsoft.Extensions.DependencyInjection;
using PlaneTicketReservationSystem.Business;
using PlaneTicketReservationSystem.Business.Helpers;
using PlaneTicketReservationSystem.Business.Interfaces;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Infrastructure
{
    public static class ProviderServiceCollection
    {
        public static IServiceCollection AddProviderServices(this IServiceCollection services)
        {
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<ITokenProvider, TokenProvider>();

            return services;
        }
    }
}
