using System.Collections.Generic;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.AirportModels;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.CountryModels;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.CityModels
{
    public class CityDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public CountryResponse Country { get; set; }
        public List<AirportResponse> Airports { get; set; }
    }
}
