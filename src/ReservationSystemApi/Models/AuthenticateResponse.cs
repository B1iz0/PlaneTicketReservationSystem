namespace PlaneTicketReservationSystem.ReservationSystemApi.Models
{
    public class AuthenticateResponse
    {
        public string JwtToken { get; set; }

        public string RefreshToken { get; set; }
    }
}
