using System.Collections.Generic;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.CityModels;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.CompanyModels;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.FlightModels;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.AirportModels
{
    public class AirportDetails
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CityResponse City { get; set; }

        public CompanyResponse Company { get; set; }

        public List<FlightResponse> ArrivingAirplanes { get; set; }

        public List<FlightResponse> OutgoingAirplanes { get; set; }
    }
}
