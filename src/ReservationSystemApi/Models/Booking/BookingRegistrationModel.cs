using System;
using System.Collections.Generic;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.Booking
{
    public class BookingRegistrationModel
    {
        public Guid FlightId { get; set; }

        public Guid? UserId { get; set; }

        public IEnumerable<Guid> PlacesId { get; set; }

        public double BaggageWeightInKilograms { get; set; }

        public string CustomerFirstName { get; set; }

        public string CustomerLastName { get; set; }

        public string CustomerEmail { get; set; }

        public decimal PlacesTotalPrice { get; set; }

        public decimal BaggageTotalPrice { get; set; }
    }
}
