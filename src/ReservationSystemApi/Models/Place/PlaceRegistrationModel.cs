namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.Place
{
    public class PlaceRegistrationModel
    {
        public int AirplaneId { get; set; }

        public int PlaceTypeId { get; set; }

        public int? PriceId { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }
    }
}
