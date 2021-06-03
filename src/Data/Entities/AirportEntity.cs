using System.Collections.Generic;

namespace PlaneTicketReservationSystem.Data.Entities
{
    public class AirportEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CityId { get; set; }
        public virtual CityEntity City { get; set; }

        public int CompanyId { get; set; }
        public virtual CompanyEntity Company { get; set; }

        public virtual List<FlightEntity> ArrivingAirplanes { get; set; }

        public virtual List<FlightEntity> OutgoingAirplanes { get; set; }
    }
}
