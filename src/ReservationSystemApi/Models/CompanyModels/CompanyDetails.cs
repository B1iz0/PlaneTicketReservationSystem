using System.Collections.Generic;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.AirplaneModels;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.AirportModels;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.CountryModels;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.CompanyModels
{
    public class CompanyDetails
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CountryResponse Country { get; set; }

        public List<AirplaneResponse> Airplanes { get; set; }

        public List<AirportResponse> Airports { get; set; }
    }
}
