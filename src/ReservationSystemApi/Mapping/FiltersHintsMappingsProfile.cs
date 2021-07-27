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
        }
    }
}