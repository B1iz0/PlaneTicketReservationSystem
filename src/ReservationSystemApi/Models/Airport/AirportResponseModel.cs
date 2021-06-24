using PlaneTicketReservationSystem.ReservationSystemApi.Models.City;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Company;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.Airport
{
    public class AirportResponseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CityResponseModel City { get; set; }

        public CompanyResponseModel Company { get; set; }
    }
}
