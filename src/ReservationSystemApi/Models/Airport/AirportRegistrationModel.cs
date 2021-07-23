using System;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.Airport
{
    public class AirportRegistrationModel
    {
        public string Name { get; set; }

        public Guid CityId { get; set; }

        public Guid CompanyId { get; set; }
    }
}
