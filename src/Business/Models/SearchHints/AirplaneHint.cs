using System;

namespace PlaneTicketReservationSystem.Business.Models.SearchHints
{
    public class AirplaneHint
    {
        public Guid Id { get; set; }

        public string AirplaneType { get; set; }

        public string CompanyName { get; set; }

        public string Model { get; set; }
    }
}