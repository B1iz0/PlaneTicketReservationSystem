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
        public int CityId { get; set; }
        public virtual CityResponse City { get; set; }
        public int CompanyId { get; set; }
        public virtual CompanyResponse Company { get; set; }
        public virtual List<FlightResponse> ArrivingAirplanes { get; set; }
        public virtual List<FlightResponse> OutgoingAirplanes { get; set; }
    }
}
