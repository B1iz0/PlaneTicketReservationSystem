using System.Collections.Generic;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.City;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Company;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Flight;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.Airport
{
    public class AirportDetailsModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CityResponseModel City { get; set; }

        public CompanyResponseModel Company { get; set; }

        public List<FlightResponseModel> ArrivingAirplanes { get; set; }

        public List<FlightResponseModel> OutgoingAirplanes { get; set; }
    }
}
