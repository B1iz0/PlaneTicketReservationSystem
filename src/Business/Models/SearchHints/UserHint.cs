using System;

namespace PlaneTicketReservationSystem.Business.Models.SearchHints
{
    public class UserHint
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}