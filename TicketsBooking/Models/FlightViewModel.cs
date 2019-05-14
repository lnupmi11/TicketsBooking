using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketsBooking.Models
{
    public class FlightViewModel
    {
        public string cityFrom { get; set; }
        public string cityTo { get; set; }
        public DateTime dateTime { get; set; }

        public DateTime dateTimeDeparture { get; set; }
        public DateTime dateTimeArriving { get; set; }
        public int Count { get; set; }
    }
}
