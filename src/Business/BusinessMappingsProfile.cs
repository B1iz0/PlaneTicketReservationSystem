using AutoMapper;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Business.Models.SearchHints;
using PlaneTicketReservationSystem.Data.Entities;

namespace PlaneTicketReservationSystem.Business
{
    public class BusinessMappingsProfile : Profile
    {
        public BusinessMappingsProfile()
        {
            CreateMap<AirplaneEntity, Airplane>().ReverseMap();
            CreateMap<AirplaneTypeEntity, AirplaneType>().ReverseMap();
            CreateMap<CompanyEntity, Company>().ReverseMap();
            CreateMap<AirportEntity, Airport>().ReverseMap();
            CreateMap<FlightEntity, Flight>().ReverseMap();
            CreateMap<Flight, FlightHint>()
                .ForMember(hint => hint.DepartureCity, opt => opt.MapFrom(flight => flight.From.City.Name))
                .ForMember(hint => hint.ArrivalCity, opt => opt.MapFrom(flight => flight.To.City.Name));
            CreateMap<CityEntity, City>().ReverseMap();
            CreateMap<CountryEntity, Country>().ReverseMap();
            CreateMap<BookingEntity, Booking>().ReverseMap();
            CreateMap<RoleEntity, Role>().ReverseMap();
            CreateMap<UserEntity, User>().ReverseMap();
            CreateMap<RefreshTokenEntity, RefreshToken>().ReverseMap();
            CreateMap<PriceEntity, Price>().ReverseMap();
            CreateMap<PlaceEntity, Place>().ReverseMap();
            CreateMap<PlaceTypeEntity, PlaceType>().ReverseMap();
        }
    }
}
