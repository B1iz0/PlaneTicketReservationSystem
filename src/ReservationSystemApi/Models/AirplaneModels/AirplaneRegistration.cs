namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.AirplaneModels
{
    public class AirplaneRegistration
    {
        public int AirplaneTypeId { get; set; }

        public int CompanyId { get; set; }

        public string Model { get; set; }

        public int RegistrationNumber { get; set; }

        public int Rows { get; set; }

        public int Columns { get; set; }
    }
}
