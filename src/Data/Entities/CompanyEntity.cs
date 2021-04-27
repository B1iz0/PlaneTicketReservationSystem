using System.Collections.Generic;

namespace PlaneTicketReservationSystem.Data.Entities
{
    public class CompanyEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public CountryEntity Country { get; set; }
        public List<AirplaneEntity> Airplanes { get; set; }
        public List<AirportEntity> Airports { get; set; }
    }
}
