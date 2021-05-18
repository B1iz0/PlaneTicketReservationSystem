using System.Collections.Generic;

namespace PlaneTicketReservationSystem.Business.Models
{
    public class Airplane
    {
        public int Id { get; set; }
        public int AirplaneTypeId { get; set; }
        public AirplaneType AirplaneType { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int? FlightId { get; set; }
        public Flight Flight { get; set; }
        public string Model { get; set; }
        public int RegistrationNumber { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public List<Place> Places { get; set; }
        public List<Price> Prices { get; set; }
    }
}
