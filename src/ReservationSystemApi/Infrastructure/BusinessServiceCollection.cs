using Microsoft.Extensions.DependencyInjection;
using PlaneTicketReservationSystem.Business.Interfaces;
using PlaneTicketReservationSystem.Business.Services;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Infrastructure
{
    public static class BusinessServiceCollection
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAirplaneService, AirplaneService>();
            services.AddScoped<IAirplaneTypeService, AirplaneTypeService>();
            services.AddScoped<IAirportService, AirportService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IFlightService, FlightService>();
            services.AddScoped<IPlaceService, PlaceService>();
            services.AddScoped<IPlaceTypeService, PlaceTypeService>();
            services.AddScoped<IPriceService, PriceService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
