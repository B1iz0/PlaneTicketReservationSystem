using System;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.SearchHints
{
    public class UserHintModel
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}