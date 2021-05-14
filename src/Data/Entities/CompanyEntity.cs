using System.Collections.Generic;

namespace PlaneTicketReservationSystem.Data.Entities
{
    public class CompanyEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public virtual List<UserEntity> Admins { get; set; }
        public virtual CountryEntity Country { get; set; }
        public virtual List<AirplaneEntity> Airplanes { get; set; }
        public virtual List<AirportEntity> Airports { get; set; }
    }
}
