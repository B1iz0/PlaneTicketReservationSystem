using System;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.User
{
    public class UserResponseModel
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Guid? CompanyId { get; set; }

        public Guid RoleId { get; set; }

        public string RoleName { get; set; }

        public string PhoneNumber { get; set; }
    }
}
