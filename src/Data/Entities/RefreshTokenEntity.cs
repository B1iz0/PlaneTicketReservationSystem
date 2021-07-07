using System;
using Microsoft.EntityFrameworkCore;

namespace PlaneTicketReservationSystem.Data.Entities
{
    [Owned]
    public class RefreshTokenEntity
    {
        public Guid Id { get; set; }

        public string Token { get; set; }

        public DateTime Expires { get; set; }

        public bool IsExpired => DateTime.UtcNow >= Expires;

        public DateTime Created { get; set; }

        public DateTime? Revoked { get; set; }

        public bool IsActive => Revoked == null && !IsExpired;
    }
}
