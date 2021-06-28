using System;
using System.Collections.Generic;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Airplane;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Airport;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Country;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.Company
{
    public class CompanyDetailsModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public CountryResponseModel Country { get; set; }

        public List<AirplaneResponseModel> Airplanes { get; set; }

        public List<AirportResponseModel> Airports { get; set; }
    }
}
