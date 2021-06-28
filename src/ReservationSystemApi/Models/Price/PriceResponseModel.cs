using System;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.Price
{
    public class PriceResponseModel
    {
        public Guid Id { get; set; }

        public Guid AirplaneId { get; set; }

        public string AirplaneModel { get; set; }

        public string PlaceType { get; set; }

        public decimal TicketPrice { get; set; }
    }
}
