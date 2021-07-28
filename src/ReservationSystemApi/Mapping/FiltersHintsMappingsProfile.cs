using AutoMapper;
using PlaneTicketReservationSystem.Business.Models.SearchFilters;
using PlaneTicketReservationSystem.Business.Models.SearchHints;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.SearchFilters;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.SearchHints;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Mapping
{
    public class FiltersHintsMappingsProfile : Profile
    {
        public FiltersHintsMappingsProfile()
        {
            CreateMap<FlightFilter, FlightFilterModel>().ReverseMap();
            CreateMap<FlightHint, FlightHintModel>().ReverseMap();
            CreateMap<UserFilter, UserFilterModel>().ReverseMap();
            CreateMap<UserHint, UserHintModel>().ReverseMap();
            CreateMap<CompanyFilter, CompanyFilterModel>().ReverseMap();
            CreateMap<CompanyHint, CompanyHintModel>().ReverseMap();
            CreateMap<AirplaneFilter, AirplaneFilterModel>().ReverseMap();
            CreateMap<AirplaneHint, AirplaneHintModel>().ReverseMap();
            CreateMap<AirportFilter, AirportFilterModel>().ReverseMap();
            CreateMap<AirportHint, AirportHintModel>().ReverseMap();
        }
    }
}