using PlaneTicketReservationSystem.ReservationSystemApi.Models.Country;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.City
{
    public class CityResponseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CountryResponseModel Country { get; set; }
    }
}
