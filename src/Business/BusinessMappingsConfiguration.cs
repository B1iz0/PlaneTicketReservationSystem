using AutoMapper;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Data.Entities;

namespace PlaneTicketReservationSystem.Business
{
    public class BusinessMappingsConfiguration
    {
        public readonly MapperConfiguration UserConfiguration;
        public readonly MapperConfiguration RoleConfiguration;
        public readonly MapperConfiguration AirplaneConfiguration;
        public readonly MapperConfiguration AirplaneTypeConfiguration;
        public readonly MapperConfiguration AirportConfiguration;
        public readonly MapperConfiguration BookingConfiguration;
        public readonly MapperConfiguration CityConfiguration;
        public readonly MapperConfiguration CompanyConfiguration;
        public readonly MapperConfiguration CountryConfiguration;
        public readonly MapperConfiguration FlightConfiguration;

        public BusinessMappingsConfiguration()
        {
            UserConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<UserEntity, User>();
                x.CreateMap<User, UserEntity>();
                x.CreateMap<RoleEntity, Role>();
            });
            RoleConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<RoleEntity, Role>();
                x.CreateMap<Role, RoleEntity>();
                x.CreateMap<UserEntity, User>();
            });
            AirplaneConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<AirplaneEntity, Airplane>();
                x.CreateMap<Airplane, AirplaneEntity>();
                x.CreateMap<AirplaneTypeEntity, AirplaneTypeEntity>();
                x.CreateMap<CompanyEntity, Company>();
                x.CreateMap<FlightEntity, Flight>();
            });
            AirplaneTypeConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<AirplaneTypeEntity, AirplaneType>();
                x.CreateMap<AirplaneType, AirplaneTypeEntity>();
                x.CreateMap<AirplaneEntity, Airplane>();
            });
            AirportConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<AirportEntity, Airport>();
                x.CreateMap<Airport, AirportEntity>();
                x.CreateMap<CityEntity, City>();
                x.CreateMap<CompanyEntity, Company>();
                x.CreateMap<FlightEntity, Flight>();
            });
            BookingConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<BookingEntity, Booking>();
                x.CreateMap<Booking, BookingEntity>();
                x.CreateMap<FlightEntity, Flight>();
                x.CreateMap<UserEntity, User>();
            });
            CityConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<CityEntity, City>().ReverseMap();
                x.CreateMap<CountryEntity, Country>();
                x.CreateMap<AirportEntity, Airport>();
            });
            CompanyConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<CompanyEntity, Company>();
                x.CreateMap<Company, CompanyEntity>();
                x.CreateMap<CountryEntity, Country>();
                x.CreateMap<AirplaneEntity, Airplane>();
            });
            CountryConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<CountryEntity, Country>();
                x.CreateMap<Country, CountryEntity>();
                x.CreateMap<CityEntity, City>();
                x.CreateMap<CompanyEntity, Company>();
            });
            FlightConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<FlightEntity, Flight>();
                x.CreateMap<Flight, FlightEntity>();
                x.CreateMap<AirplaneEntity, Airplane>();
                x.CreateMap<AirportEntity, Airport>();
                x.CreateMap<BookingEntity, Booking>();
            });
        }
    }
}
