using System;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.SearchHints
{
    public class CompanyHintModel
    {
        public Guid Id { get; set; }

        public string CompanyName { get; set; }

        public string CountryName { get; set; }
    }
}