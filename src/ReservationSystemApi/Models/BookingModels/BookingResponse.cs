using PlaneTicketReservationSystem.ReservationSystemApi.Models.FlightModels;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.UserModels;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.BookingModels
{
    public class BookingResponse
    {
        public int Id { get; set; }
        public FlightResponse Flight { get; set; }
        public UserResponse User { get; set; }
    }
}
