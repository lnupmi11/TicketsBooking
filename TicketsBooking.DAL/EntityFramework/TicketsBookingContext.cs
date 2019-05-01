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
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<City> Cities { get; set; }
        //public DbSet<TicketType> TicketTypes { get; set; }


        public TicketsBookingContext(DbContextOptions<TicketsBookingContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BasketItem>()
            .HasKey(t => new { t.BasketId, t.TicketId });

            modelBuilder.Entity<BasketItem>()
                .HasOne(sc => sc.Basket)
                .WithMany(s => s.MenuItems)
                .HasForeignKey(sc => sc.BasketId);

            modelBuilder.Entity<BasketItem>()
                .HasOne(sc => sc.Ticket)
                .WithMany(c => c.Baskets)
                .HasForeignKey(sc => sc.TicketId);
        }
    }
}
