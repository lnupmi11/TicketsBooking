using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketsBooking.DAL.Entities
{
    public class Basket
    {
        [Key]
        public int Id { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public string UserId { get; set; }
    }
}
