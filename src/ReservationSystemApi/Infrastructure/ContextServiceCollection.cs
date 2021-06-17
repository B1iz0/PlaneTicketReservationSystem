using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlaneTicketReservationSystem.Data;
using PlaneTicketReservationSystem.ReservationSystemApi.Helpers;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Infrastructure
{
    public static class ContextServiceCollection
    {
        public static IServiceCollection AddContextServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ReservationSystemContext>(opt =>
            {
                opt.UseLazyLoadingProxies();
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<ContextInitializer>();

            return services;
        }
    }
}
