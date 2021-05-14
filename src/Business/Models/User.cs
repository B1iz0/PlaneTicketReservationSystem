using System.Collections.Generic;

namespace PlaneTicketReservationSystem.Business.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
