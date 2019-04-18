using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace TicketsBooking.DAL.Entities
{
    public class User : IdentityUser
    {
        private string _email;
        private int _id;

        public int Id { get => _id; set => _id = value; }

        public string Email { get => _email; set => _email = value; }

        public DateTime Year { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
