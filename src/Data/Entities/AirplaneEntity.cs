namespace PlaneTicketReservationSystem.Data.Entities
{
    public class AirplaneEntity
    {
        public int Id { get; set; }
        public int AirplaneTypeId { get; set; }
        public virtual AirplaneTypeEntity AirplaneType { get; set; }
        public int CompanyId { get; set; }
        public virtual CompanyEntity Company { get; set; }
        public int? FlightId { get; set; }
        public virtual FlightEntity Flight { get; set; }
        public int ModelNumber { get; set; }
        public short RegistrationNumber { get; set; }
        public long Capacity { get; set; }
    }
}
