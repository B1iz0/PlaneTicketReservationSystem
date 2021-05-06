namespace PlaneTicketReservationSystem.Business.Models
{
    public class Airplane
    {
        public int Id { get; set; }
        public int AirplaneTypeId { get; set; }
        public virtual AirplaneType AirplaneType { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public int? FlightId { get; set; }
        public virtual Flight Flight { get; set; }
        public int ModelNumber { get; set; }
        public short RegistrationNumber { get; set; }
        public long Capacity { get; set; }
    }
}
