using System;
using System.Collections.Generic;

namespace PlaneTicketReservationSystem.Business.Models
{
    public class Airplane
    {
        public Guid Id { get; set; }

        public Guid AirplaneTypeId { get; set; }
        public AirplaneType AirplaneType { get; set; }

        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        public Guid? FlightId { get; set; }
        public Flight Flight { get; set; }

        public string Model { get; set; }

        public int RegistrationNumber { get; set; }

        public int Rows { get; set; }

        public int Columns { get; set; }

        public double BaggageCapacityInKilograms { get; set; }

        public double OnePersonBaggageLimitInKilograms => BaggageCapacityInKilograms / (Rows * Columns);

        public List<Place> Places { get; set; }

        public List<Price> Prices { get; set; }
    }
}
