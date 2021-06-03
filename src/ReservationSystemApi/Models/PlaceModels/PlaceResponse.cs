namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.PlaceModels
{
    public class PlaceResponse
    {
        public int Id { get; set; }

        public string PlaceType { get; set; }

        public decimal TicketPrice { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }

        public bool IsFree { get; set; }
    }
}
