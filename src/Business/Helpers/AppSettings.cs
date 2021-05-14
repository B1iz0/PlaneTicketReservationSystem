namespace PlaneTicketReservationSystem.Business.Helpers
{
    public class AppSettings
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int LifeTime { get; set; }
        public int RefreshTokenLifeTime { get; set; }
        public string Key { get; set; }
    }
}
