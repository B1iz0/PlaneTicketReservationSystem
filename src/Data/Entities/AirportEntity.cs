using System.Collections.Generic;

namespace PlaneTicketReservationSystem.Data.Entities
{
    public class AirportEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public CityEntity City { get; set; }
        public int CompanyId { get; set; }
        public CompanyEntity Company { get; set; }
        public List<FlightEntity> ArrivingAirplanes { get; set; } = new List<FlightEntity>();
        public List<FlightEntity> OutgoingAirplanes { get; set; } = new List<FlightEntity>();
    }
}
