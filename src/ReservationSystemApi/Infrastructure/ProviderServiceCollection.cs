using Microsoft.Extensions.DependencyInjection;
using PlaneTicketReservationSystem.Business.Helpers;
using PlaneTicketReservationSystem.Business.Interfaces;
using PlaneTicketReservationSystem.Data;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Infrastructure
{
    public static class ProviderServiceCollection
    {
        public static IServiceCollection AddProviderServices(this IServiceCollection services)
        {
            services.AddScoped<IPasswordProvider, PasswordProvider>();
            services.AddScoped<ITokenProvider, TokenProvider>();

            return services;
        }
    }
}
