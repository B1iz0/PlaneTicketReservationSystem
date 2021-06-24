namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.Price
{
    public class PriceRegistrationModel
    {
        public int AirplaneId { get; set; }

        public int PlaceTypeId { get; set; }

        public decimal TicketPrice { get; set; }
    }
}
