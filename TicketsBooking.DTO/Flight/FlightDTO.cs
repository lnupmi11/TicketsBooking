using System;
using System.Collections.Generic;
using System.Text;
using TicketsBooking.DTO.Ticket;

namespace TicketsBooking.DTO.Flight
{
    public class FlightDTO
    {
        public int Id { get; set; }
        public string LocationFrom { get; set; }
        public string LocationTo { get; set; }
        public int NumberOfSeats { get; set; }
        public DateTime FlightDepartmentDate { get; set; }
        public DateTime FlightArrivingDate { get; set; }
        public ICollection<TicketDTO> Tickets { get; set; }
    }
}
