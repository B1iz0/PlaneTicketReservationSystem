using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.AirplaneModels;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.AirportModels;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.BookingModels;

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
