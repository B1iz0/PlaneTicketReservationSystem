using System;

namespace PlaneTicketReservationSystem.Business.Models.SearchHints
{
    public class CompanyHint
    {
        public Guid Id { get; set; }

        public string CompanyName { get; set; }

        public string CountryName { get; set; }
    }
}