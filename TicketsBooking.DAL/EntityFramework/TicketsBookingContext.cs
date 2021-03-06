﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TicketsBooking.DAL.Entities;

namespace TicketsBooking.DAL.EntityFramework
{
    public sealed class TicketsBookingContext : IdentityDbContext<User>
    {
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }
        public DbSet<BoughtTicket> BoughtTickets { get; set; }
        public DbSet<Flight> Flights { get; set; }

        public DbSet<Like> Likes { get; set; }

        public TicketsBookingContext() { }
        public TicketsBookingContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
