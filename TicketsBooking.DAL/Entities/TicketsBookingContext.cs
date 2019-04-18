using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TicketsBooking.DAL.Entities
{
    public sealed class TicketsBookingContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
