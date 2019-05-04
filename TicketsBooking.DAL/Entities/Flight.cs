using System;
using System.Collections.Generic;
using System.Text;

namespace TicketsBooking.DAL.Entities
{
    public class Flight
    {
        public int Id { get; set; }
        public City LocationFrom { get; set; }
        public City LocationTo { get; set; }
        public int NumberOfSeats { get; set; }
        public DateTime FlightDepartmentDate { get; set; }

        public DateTime FlightArrivingDate { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
