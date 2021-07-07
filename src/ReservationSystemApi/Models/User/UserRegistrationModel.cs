using System;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.User
{
    public class UserRegistrationModel
    {
        public string Email { get; set; }

        public Guid RoleId { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
