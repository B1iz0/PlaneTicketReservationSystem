namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.Authenticate
{
    public class AuthenticateResponseModel
    {
        public string JwtToken { get; set; }

        public string RefreshToken { get; set; }
    }
}
