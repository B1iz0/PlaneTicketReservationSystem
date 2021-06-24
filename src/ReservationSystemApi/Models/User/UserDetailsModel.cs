using System.Collections.Generic;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Booking;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Role;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.User
{
    public class UserDetailsModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public RoleResponseModel Role { get; set; }

        public List<BookingResponseModel> Bookings { get; set; }
    }
}
