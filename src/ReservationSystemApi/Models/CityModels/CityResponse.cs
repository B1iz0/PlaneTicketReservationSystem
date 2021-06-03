using PlaneTicketReservationSystem.ReservationSystemApi.Models.CountryModels;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.CityModels
{
    public class CityResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CountryResponse Country { get; set; }
    }
}
