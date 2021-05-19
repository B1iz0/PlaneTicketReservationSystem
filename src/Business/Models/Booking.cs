namespace PlaneTicketReservationSystem.Business.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public Flight Flight { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int PlaceId { get; set; }
        public Place Place { get; set; }
    }
}
