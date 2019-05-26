using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketsBooking.DAL.Entities;
using TicketsBooking.DTO.Flight;
using TicketsBooking.DTO.Ticket;

namespace TicketsBooking.Models
{
    public class AddTicketModel
    {
        public IEnumerable<FlightDTO> Flights { get; set; }
        public IEnumerable<TicketTypeDTO> Types { get; set; }
    }
}
