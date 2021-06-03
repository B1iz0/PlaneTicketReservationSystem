using PlaneTicketReservationSystem.ReservationSystemApi.Models.CountryModels;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.CompanyModels
{
    public class CompanyResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CountryResponse Country { get; set; }
    }
}
