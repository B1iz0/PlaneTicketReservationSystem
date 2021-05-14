using System.Collections.Generic;

namespace PlaneTicketReservationSystem.Business.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public List<Airplane> Airplanes { get; set; }
        public List<Airport> Airports { get; set; }
    }
}
