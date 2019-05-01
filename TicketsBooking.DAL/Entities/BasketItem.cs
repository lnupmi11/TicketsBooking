using System;
using System.Collections.Generic;
using System.Text;

namespace TicketsBooking.DAL.Entities
{
    public class BasketItem
    {
        public string BasketId { get; set; }
        public string TicketId { get; set; }
        public int Count { get; set; }
        public Basket Basket { get; set; }
        public Ticket Ticket { get; set; }
    }
}
