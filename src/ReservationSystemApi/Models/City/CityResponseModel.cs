using System;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Country;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.City
{
    public class CityResponseModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public CountryResponseModel Country { get; set; }
    }
}
