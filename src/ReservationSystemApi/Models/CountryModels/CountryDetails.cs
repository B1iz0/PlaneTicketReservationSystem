using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.CityModels;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.CompanyModels;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.CountryModels
{
    public class CountryDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CityResponse> Cities { get; set; }
        public List<CompanyResponse> Companies { get; set; }
    }
}
