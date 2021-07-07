using System;
using System.Collections.Generic;

namespace PlaneTicketReservationSystem.Business.Models
{
    public class Airport
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid CityId { get; set; }
        public City City { get; set; }

        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        public List<Flight> ArrivingAirplanes { get; set; }

        public List<Flight> OutgoingAirplanes { get; set; }
    }
}
