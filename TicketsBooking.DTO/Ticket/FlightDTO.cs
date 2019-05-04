using System;
using System.Collections.Generic;
using System.Text;

namespace TicketsBooking.DTO.Ticket
{
    class FlightDTO
    {
        public int Id { get; set; }
        public CityDTO LocationFrom { get; set; }
        public CityDTO LocationTo { get; set; }
        public int NumberOfSeats { get; set; }
        public DateTime FlightDepartmentDate { get; set; }
        public DateTime FlightArrivingDate { get; set; }
    }
}
