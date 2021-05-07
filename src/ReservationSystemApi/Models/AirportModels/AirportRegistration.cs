namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.AirportModels
{
    public class AirportRegistration
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public int CompanyId { get; set; }
    }
}
