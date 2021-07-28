using System;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.SearchHints
{
    public class AirplaneHintModel
    {
        public Guid Id { get; set; }

        public string AirplaneType { get; set; }

        public string CompanyName { get; set; }

        public string Model { get; set; }
    }
}