using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TicketsBooking.DAL.Entities;

namespace TicketsBooking.DAL.EntityFramework
{
    public sealed class TicketsBookingContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        public TicketsBookingContext(DbContextOptions<TicketsBookingContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
