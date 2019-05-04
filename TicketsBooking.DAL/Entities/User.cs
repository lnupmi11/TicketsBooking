using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace TicketsBooking.DAL.Entities
{
    public class User : IdentityUser
    {

        public DateTime Year { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Basket Basket { get; set; }
    }
}
