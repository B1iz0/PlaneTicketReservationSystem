using PlaneTicketReservationSystem.ReservationSystemApi.Models.Flight;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Place;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.User;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.Booking
{
    public class BookingResponseModel
    {
        public int Id { get; set; }

        public FlightResponseModel Flight { get; set; }

        public UserResponseModel User { get; set; }

        public PlaceResponseModel Place { get; set; }
    }
}
