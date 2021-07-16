using System;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.Airplane
{
    public class AirplaneRegistrationModel
    {
        public Guid AirplaneTypeId { get; set; }

        public Guid CompanyId { get; set; }

        public string Model { get; set; }

        public int RegistrationNumber { get; set; }

        public int Rows { get; set; }

        public int Columns { get; set; }

        public double BaggageCapacityInKilograms { get; set; }
    }
}
