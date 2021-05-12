using AutoMapper;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Data.Entities;

namespace PlaneTicketReservationSystem.Business
{
    public class BusinessMappingsConfiguration
    {
        public readonly MapperConfiguration AirlineConfiguration;

        public BusinessMappingsConfiguration()
        {
            AirlineConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<AirplaneEntity, Airplane>().ReverseMap();
                x.CreateMap<AirplaneTypeEntity, AirplaneType>().ReverseMap();
                x.CreateMap<CompanyEntity, Company>().ReverseMap();
                x.CreateMap<AirportEntity, Airport>().ReverseMap();
                x.CreateMap<FlightEntity, Flight>().ReverseMap();
                x.CreateMap<CityEntity, City>().ReverseMap();
                x.CreateMap<CountryEntity, Country>().ReverseMap();
                x.CreateMap<BookingEntity, Booking>().ReverseMap();
                x.CreateMap<RoleEntity, Role>().ReverseMap();
                x.CreateMap<UserEntity, User>().ReverseMap();
                x.CreateMap<RefreshTokenEntity, RefreshToken>().ReverseMap();
            });
        }
    }
}
