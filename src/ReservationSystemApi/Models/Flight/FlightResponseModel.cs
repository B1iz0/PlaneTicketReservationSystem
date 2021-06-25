using System;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Airplane;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Airport;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.Flight
{
    public class FlightResponseModel
    {
        public int Id { get; set; }

        public AirplaneResponseModel Airplane { get; set; }

        public string FlightNumber { get; set; }

        public AirportResponseModel From { get; set; }

        public AirportResponseModel To { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }
    }
}
