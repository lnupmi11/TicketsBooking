using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketsBooking.Models
{
    public class AddTicketResultModel
    {
        public double Price { get; set; }
        public string TypeID { get; set; }
        public int FlightID { get; set; }

        public int Amount { get; set; }
    }
}
