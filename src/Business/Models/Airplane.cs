namespace PlaneTicketReservationSystem.Business.Models
{
    public class Airplane
    {
        public int Id { get; set; }
        public int AirplaneTypeId { get; set; }
        public AirplaneType AirplaneType { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int? FlightId { get; set; }
        public Flight Flight { get; set; }
        public int ModelNumber { get; set; }
        public short RegistrationNumber { get; set; }
        public long Capacity { get; set; }
    }
}
