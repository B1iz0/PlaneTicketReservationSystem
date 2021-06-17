using Microsoft.Extensions.DependencyInjection;
using PlaneTicketReservationSystem.Data.Interfaces;
using PlaneTicketReservationSystem.Data.Repositories;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Infrastructure
{
    public static class RepositoryServiceCollection
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IAirplaneRepository, AirplaneRepository>();
            services.AddScoped<IAirplaneTypeRepository, AirplaneTypeRepository>();
            services.AddScoped<IAirportRepository, AirportRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IFlightRepository, FlightRepository>();
            services.AddScoped<IPlaceRepository, PlaceRepository>();
            services.AddScoped<IPlaceTypeRepository, PlaceTypeRepository>();
            services.AddScoped<IPriceRepository, PriceRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
