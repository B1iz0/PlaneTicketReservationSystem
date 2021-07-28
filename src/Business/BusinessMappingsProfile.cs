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
            CreateMap<Airplane, AirplaneHint>()
                .ForMember(hint => hint.AirplaneType, opt => opt.MapFrom(airplane => airplane.AirplaneType.TypeName))
                .ForMember(hint => hint.CompanyName, opt => opt.MapFrom(airplane => airplane.Company.Name));
            CreateMap<AirplaneTypeEntity, AirplaneType>().ReverseMap();
            CreateMap<CompanyEntity, Company>().ReverseMap();
            CreateMap<Company, CompanyHint>()
                .ForMember(hint => hint.CompanyName, opt => opt.MapFrom(company => company.Name))
                .ForMember(hint => hint.CountryName, opt => opt.MapFrom(company => company.Country.Name));
            CreateMap<AirportEntity, Airport>().ReverseMap();
            CreateMap<Airport, AirportHint>()
                .ForMember(hint => hint.AirportName, opt => opt.MapFrom(airport => airport.Name))
                .ForMember(hint => hint.CityName, opt => opt.MapFrom(airport => airport.City.Name))
                .ForMember(hint => hint.CountryName, opt => opt.MapFrom(airport => airport.City.Country.Name))
                .ForMember(hint => hint.CompanyName, opt => opt.MapFrom(airport => airport.Company.Name));
            CreateMap<FlightEntity, Flight>().ReverseMap();
            CreateMap<Flight, FlightHint>()
                .ForMember(hint => hint.DepartureCity, opt => opt.MapFrom(flight => flight.From.City.Name))
                .ForMember(hint => hint.ArrivalCity, opt => opt.MapFrom(flight => flight.To.City.Name));
            CreateMap<CityEntity, City>().ReverseMap();
            CreateMap<CountryEntity, Country>().ReverseMap();
            CreateMap<BookingEntity, Booking>().ReverseMap();
            CreateMap<RoleEntity, Role>().ReverseMap();
            CreateMap<UserEntity, User>().ReverseMap();
            CreateMap<User, UserHint>();
            CreateMap<RefreshTokenEntity, RefreshToken>().ReverseMap();
            CreateMap<PriceEntity, Price>().ReverseMap();
            CreateMap<PlaceEntity, Place>().ReverseMap();
            CreateMap<PlaceTypeEntity, PlaceType>().ReverseMap();
        }
    }
}
