using System;
using System.Collections.Generic;
using System.Text;

namespace TicketsBooking.DAL.Entities
{
    public class BoughtTicket
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string LocationFrom { get; set; }
        public string LocationTo { get; set; }

    }
}
