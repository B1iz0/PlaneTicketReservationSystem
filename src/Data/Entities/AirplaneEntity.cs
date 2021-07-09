using System;
using System.Collections.Generic;

namespace PlaneTicketReservationSystem.Data.Entities
{
    public class AirplaneEntity
    {
        public Guid Id { get; set; }

        public Guid AirplaneTypeId { get; set; }
        public virtual AirplaneTypeEntity AirplaneType { get; set; }

        public Guid CompanyId { get; set; }
        public virtual CompanyEntity Company { get; set; }

        public Guid? FlightId { get; set; }
        public virtual FlightEntity Flight { get; set; }

        public string Model { get; set; }
        public int RegistrationNumber { get; set; }

        public int Rows { get; set; }

        public int Columns { get; set; }

        public double BaggageCapacityInKilograms { get; set; }

        public virtual List<PlaceEntity> Places { get; set; }

        public virtual List<PriceEntity> Prices { get; set; }
    }
}
