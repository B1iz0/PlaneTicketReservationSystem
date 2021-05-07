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
                x.CreateMap<UserEntity, User>().ReverseMap();
                x.CreateMap<RoleEntity, Role>();
            });
            RoleConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<RoleEntity, Role>().ReverseMap();
                x.CreateMap<UserEntity, User>();
            });
            AirplaneConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<AirplaneEntity, Airplane>().ReverseMap();
                x.CreateMap<AirplaneTypeEntity, AirplaneTypeEntity>();
                x.CreateMap<CompanyEntity, Company>();
                x.CreateMap<FlightEntity, Flight>();
            });
            AirplaneTypeConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<AirplaneTypeEntity, AirplaneType>().ReverseMap();
                x.CreateMap<AirplaneEntity, Airplane>();
            });
            AirportConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<AirportEntity, Airport>().ReverseMap();
                x.CreateMap<CityEntity, City>();
                x.CreateMap<CompanyEntity, Company>();
                x.CreateMap<FlightEntity, Flight>();
            });
            BookingConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<BookingEntity, Booking>().ReverseMap();
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
                x.CreateMap<CompanyEntity, Company>().ReverseMap();
                x.CreateMap<CountryEntity, Country>();
                x.CreateMap<AirplaneEntity, Airplane>();
            });
            CountryConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<CountryEntity, Country>().ReverseMap();
                x.CreateMap<CityEntity, City>();
                x.CreateMap<CompanyEntity, Company>();
            });
            FlightConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<FlightEntity, Flight>().ReverseMap();
                x.CreateMap<AirplaneEntity, Airplane>();
                x.CreateMap<AirportEntity, Airport>();
                x.CreateMap<BookingEntity, Booking>();
            });
        }
    }
}
