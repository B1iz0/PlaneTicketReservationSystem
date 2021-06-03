using System.Collections.Generic;

namespace PlaneTicketReservationSystem.Business.Models
{
    public class Airport
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public List<Flight> ArrivingAirplanes { get; set; }

        public List<Flight> OutgoingAirplanes { get; set; }
    }
}
