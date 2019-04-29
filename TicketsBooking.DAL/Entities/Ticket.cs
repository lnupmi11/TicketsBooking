using System;
using System.Collections.Generic;
using System.Text;

namespace TicketsBooking.DAL.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public City From { get; set; }
        public City To { get; set; }
        public TicketType Type { get; set; }
        public double Price { get; set; }
        public DateTime Depart { get; set; }
        public DateTime Arrive { get; set; }
    }
}
