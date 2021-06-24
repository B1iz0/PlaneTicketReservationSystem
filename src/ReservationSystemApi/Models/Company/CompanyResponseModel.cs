using PlaneTicketReservationSystem.ReservationSystemApi.Models.Country;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.Company
{
    public class CompanyResponseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CountryResponseModel Country { get; set; }
    }
}
