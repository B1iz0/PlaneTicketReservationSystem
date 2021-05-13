namespace PlaneTicketReservationSystem.Business.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public virtual Flight Flight { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
