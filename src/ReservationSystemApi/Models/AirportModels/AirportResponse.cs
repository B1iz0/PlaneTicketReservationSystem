using PlaneTicketReservationSystem.ReservationSystemApi.Models.CityModels;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.CompanyModels;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.AirportModels
{
    public class AirportResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CityResponse City { get; set; }
        public CompanyResponse Company { get; set; }
    }
}
