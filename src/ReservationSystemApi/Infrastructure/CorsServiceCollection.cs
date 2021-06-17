using Microsoft.Extensions.DependencyInjection;
using PlaneTicketReservationSystem.ReservationSystemApi.Helpers;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Infrastructure
{
    public static class CorsServiceCollection
    {
        public static IServiceCollection AddCorsServices(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(CorsOptions.ApiCorsName, builder =>
                {
                    builder.WithOrigins(CorsOptions.WebHost)
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            return services;
        }
    }
}
