using System;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.SearchHints
{
    public class AirportHintModel
    {
        public Guid Id { get; set; }

        public string CompanyName { get; set; }

        public string AirportName { get; set; }

        public string CityName { get; set; }

        public string CountryName { get; set; }
    }
}