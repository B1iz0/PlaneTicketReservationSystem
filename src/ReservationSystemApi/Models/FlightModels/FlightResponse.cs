using System;
using PlaneTicketReservationSystem.ReservationSystemApi.Mappers;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.AirplaneModels;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.AirportModels;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.FlightModels
{
    public class FlightResponse
    {
        public int Id { get; set; }
        public AirplaneResponse Airplane { get; set; }
        public long FlightNumber { get; set; }
        public AirportResponse From { get; set; }
        public AirportResponse To { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime ArrivalTime { get; set; }
    }
}
