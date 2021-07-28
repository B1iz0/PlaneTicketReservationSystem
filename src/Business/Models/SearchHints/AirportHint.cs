using System;

namespace PlaneTicketReservationSystem.Business.Models.SearchHints
{
    public class AirportHint
    {
        public Guid Id { get; set; }

        public string CompanyName { get; set; }

        public string AirportName { get; set; }

        public string CityName { get; set; }

        public string CountryName { get; set; }
    }
}