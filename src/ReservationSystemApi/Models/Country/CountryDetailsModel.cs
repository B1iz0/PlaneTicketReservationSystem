using System;
using System.Collections.Generic;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.City;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Company;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.Country
{
    public class CountryDetailsModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<CityResponseModel> Cities { get; set; }

        public List<CompanyResponseModel> Companies { get; set; }
    }
}
