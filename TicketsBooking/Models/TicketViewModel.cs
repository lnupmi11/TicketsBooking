using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketsBooking.DAL.Entities;
using TicketsBooking.DTO.Ticket;

namespace TicketsBooking.Models
{
    public class TicketViewModel
    {
        public int Id { get; set; }
        public string LocationFrom { get; set; }
        public string LocationTo { get; set; }
        public DateTime FlightDepartmentDate { get; set; }
        public DateTime FlightArrivingDate { get; set; }
        public double Price { get; set; }
        public TicketTypeDTO Type { get; set; }
        public int FlightId { get; set; }
    }
}
