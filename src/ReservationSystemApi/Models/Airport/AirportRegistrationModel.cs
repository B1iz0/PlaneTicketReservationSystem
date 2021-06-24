namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.Airport
{
    public class AirportRegistrationModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CityId { get; set; }

        public int CompanyId { get; set; }
    }
}
