using System;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.Price
{
    public class PriceRegistrationModel
    {
        public Guid Id { get; set; }

        public Guid AirplaneId { get; set; }

        public Guid PlaceTypeId { get; set; }

        public decimal TicketPrice { get; set; }
    }
}
