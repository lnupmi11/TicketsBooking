using System;
using System.Collections.Generic;
using System.Text;

namespace TicketsBooking.DAL.Entities
{
    public class Like
    {
        public int Id { get; set; }
        
        public string UserEmail { get; set; }

        public int FlightId { get; set; }
    }
}
