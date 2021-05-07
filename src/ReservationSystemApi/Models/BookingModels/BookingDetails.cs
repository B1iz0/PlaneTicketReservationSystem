using PlaneTicketReservationSystem.ReservationSystemApi.Models.FlightModels;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.UserModels;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.BookingModels
{
    public class BookingDetails
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public FlightResponse Flight { get; set; }
        public int UserId { get; set; }
        public UserResponse User { get; set; }
    }
}
