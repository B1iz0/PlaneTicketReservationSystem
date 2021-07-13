using System;
using System.Collections.Generic;

namespace PlaneTicketReservationSystem.Data.Entities
{
    public class BookingEntity
    {
        public Guid Id { get; set; }

        public Guid FlightId { get; set; }
        public virtual FlightEntity Flight { get; set; }

        public Guid UserId { get; set; }
        public virtual UserEntity User { get; set; }

        public virtual IEnumerable<PlaceEntity> Places { get; set; }

        public double BaggageWeightInKilograms { get; set; }

        public string CustomerFirstName { get; set; }

        public string CustomerLastName { get; set; }

        public string CustomerEmail { get; set; }
    }
}
