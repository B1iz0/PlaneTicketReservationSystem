using System;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.Company
{
    public class CompanyRegistrationModel
    {
        public string Name { get; set; }

        public Guid CountryId { get; set; }
    }
}
