using System.Collections.Generic;

namespace PlaneTicketReservationSystem.Business.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public virtual List<Airport> Airports { get; set; }
    }
}
