﻿using System;
using System.Collections.Generic;

namespace PlaneTicketReservationSystem.Business.Models
{
    public class PlaceType
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<Place> Places { get; set; }

        public List<Price> Prices { get; set; }
    }
}
