using System;
using System.Collections.Generic;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Airplane;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Airport;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Booking;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.Flight
{
    public class FlightDetailsModel
    {
        public Guid Id { get; set; }

        public AirplaneResponseModel Airplane { get; set; }

        public string FlightNumber { get; set; }

        public AirportResponseModel From { get; set; }

        public AirportResponseModel To { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public double FreeBaggageLimitInKilograms { get; set; }

        public decimal OverweightPrice { get; set; }

        public List<BookingResponseModel> Bookings { get; set; }
    }
}
