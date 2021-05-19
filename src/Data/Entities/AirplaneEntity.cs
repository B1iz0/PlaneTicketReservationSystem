using System.Collections.Generic;

namespace PlaneTicketReservationSystem.Data.Entities
{
    public class AirplaneEntity
    {
        public int Id { get; set; }
        public int AirplaneTypeId { get; set; }
        public virtual AirplaneTypeEntity AirplaneType { get; set; }
        public int CompanyId { get; set; }
        public virtual CompanyEntity Company { get; set; }
        public int? FlightId { get; set; }
        public virtual FlightEntity Flight { get; set; }
        public string Model { get; set; }
        public int RegistrationNumber { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public virtual List<PlaceEntity> Places { get; set; }
        public virtual List<PriceEntity> Prices { get; set; }
    }
}
