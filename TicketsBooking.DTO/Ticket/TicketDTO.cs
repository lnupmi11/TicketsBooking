using System;
using System.Collections.Generic;
using System.Text;

namespace TicketsBooking.DTO.Ticket
{
    public class TicketDTO
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public TicketTypeDTO Type { get; set; }

        public string CityFrom { get; set; }
        public string CityTo { get; set; }
    }
}
