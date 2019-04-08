﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketsBooking.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public City From { get; set; }
        public City To { get; set; }
        public TicketType Type { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
    }
}
