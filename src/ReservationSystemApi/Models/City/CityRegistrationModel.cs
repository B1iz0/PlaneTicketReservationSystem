using System;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.City
{
    public class CityRegistrationModel
    {
        public string Name { get; set; }

        public Guid CountryId { get; set; }
    }
}
