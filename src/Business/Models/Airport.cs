using System.Collections.Generic;

namespace PlaneTicketReservationSystem.Business.Models
{
    public class Airport
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public virtual List<Flight> ArrivingAirplanes { get; set; }
        public virtual List<Flight> OutgoingAirplanes { get; set; }
    }
}
