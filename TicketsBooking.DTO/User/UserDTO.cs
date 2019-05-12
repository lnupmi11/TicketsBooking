using System;
using System.Collections.Generic;
using System.Text;
using TicketsBooking.DAL.Entities;

namespace TicketsBooking.DTO.User
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
    }
}