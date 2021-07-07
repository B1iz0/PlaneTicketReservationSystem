namespace PlaneTicketReservationSystem.Business.Helpers
{
    public class TokenSettings
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public int LifeTime { get; set; }

        public int RefreshTokenLifeTime { get; set; }

        public int RefreshTokenBytesAmount { get; set; }

        public string Key { get; set; }
    }
}
