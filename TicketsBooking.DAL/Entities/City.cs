﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketsBooking.DAL.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public string CityCode { get; set; }
    }
}