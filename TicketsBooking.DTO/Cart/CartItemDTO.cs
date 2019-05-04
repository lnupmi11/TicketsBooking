using System;
using System.Collections.Generic;
using System.Text;
using TicketsBooking.DTO.Ticket;

namespace TicketsBooking.DTO.Cart
{
    public class CartDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }

        public IEnumerable<TicketDTO> Tickets { get; set; }
    }
}
