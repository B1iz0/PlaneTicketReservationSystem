using System;
using System.Collections.Generic;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Airport;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Country;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.City
{
    public class CityDetailsModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public CountryResponseModel Country { get; set; }

        public List<AirportResponseModel> Airports { get; set; }
    }
}
