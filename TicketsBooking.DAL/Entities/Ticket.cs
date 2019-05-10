using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketsBooking.DAL.Entities
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public TicketType Type { get; set; }
        public double Price { get; set; }
        public Basket Basket { get; set; }
        public int FlightId { get; set; }
    }
}
