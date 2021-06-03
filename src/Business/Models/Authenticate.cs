namespace PlaneTicketReservationSystem.Business.Models
{
    public class Authenticate
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string JwtToken { get; set; }

        public string RefreshToken { get; set; }

        public Authenticate() { }

        public Authenticate(User user, string jwtToken, string refreshToken)
        {
            Id = user.Id;
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
            JwtToken = jwtToken;
            RefreshToken = refreshToken;
        }
    }
}
