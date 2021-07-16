using System;
using System.Collections.Generic;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Flight;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Place;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.User;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.Booking
{
    public class BookingResponseModel
    {
        public Guid Id { get; set; }

        public FlightResponseModel Flight { get; set; }

        public UserResponseModel User { get; set; }

        public IEnumerable<PlaceResponseModel> Places { get; set; }

        public double BaggageWeightInKilograms { get; set; }

        public string CustomerFirstName { get; set; }

        public string CustomerLastName { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerPhone { get; set; }

        public decimal PlacesTotalPrice { get; set; }

        public decimal BaggageTotalPrice { get; set; }
    }
}
