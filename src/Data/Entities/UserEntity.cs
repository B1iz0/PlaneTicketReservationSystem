using System;
using System.Collections.Generic;

namespace PlaneTicketReservationSystem.Data.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public Guid RoleId { get; set; }
        public virtual RoleEntity Role { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Guid? CompanyId { get; set; }
        public virtual CompanyEntity Company { get; set; }

        public string PhoneNumber { get; set; }

        public virtual List<BookingEntity> Bookings { get; set; }

        public virtual RefreshTokenEntity RefreshToken { get; set; }
    }
}
