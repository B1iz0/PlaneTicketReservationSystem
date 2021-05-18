namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.BookingModels
{
    public class BookingRegistration
    {
        public int FlightId { get; set; }
        public int UserId { get; set; }
        public int PlaceId { get; set; }
    }
}
