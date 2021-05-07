using System.Collections.Generic;

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
