using System.Collections.Generic;
using System.Text.Json.Serialization;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.BookingModels;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.RoleModels;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.UserModels
{
    public class UserDetails
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
        public RoleResponse Role { get; set; }
        public List<BookingResponse> Bookings { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
    }
}
