using System;
using System.Collections.Generic;
using System.Text;

namespace PlaneTicketReservationSystem.Business.Helpers
{
    public class AppSettings
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int LifeTime { get; set; }
        public string Key { get; set; }
    }
}
