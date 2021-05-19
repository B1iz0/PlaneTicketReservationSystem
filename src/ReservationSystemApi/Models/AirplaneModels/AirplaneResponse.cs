using System.Collections.Generic;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.AirplaneTypeModels;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.CompanyModels;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.FlightModels;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.PlaceModels;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.PriceModels;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.AirplaneModels
{
    public class AirplaneResponse
    {
        public int Id { get; set; }
        public AirplaneTypeResponse AirplaneType { get; set; }
        public CompanyResponse Company { get; set; }
        public FlightResponse Flight { get; set; }
        public string Model { get; set; }
        public int RegistrationNumber { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public List<PlaceResponse> Places { get; set; }
        public List<PriceResponse> Prices { get; set; }
    }
}
