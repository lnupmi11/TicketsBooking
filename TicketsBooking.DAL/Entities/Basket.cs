using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketsBooking.DAL.Entities
{
    public class Basket
    {
        [Key]
        public string Id { get; set; }
        public ICollection<BasketItem> MenuItems { get; set; }
    }
}
