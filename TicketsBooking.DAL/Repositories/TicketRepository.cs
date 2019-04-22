using System;
using System.Collections.Generic;
using System.Text;
using TicketsBooking.DAL.Interfaces;
using TicketsBooking.DAL.Entities;
using TicketsBooking.DAL.EntityFramework;

namespace TicketsBooking.DAL.Repositories
{
    class TicketRepository : IRepository<Ticket>
    {
        TicketsBookingContext dbContext = new TicketsBookingContext();
        public void Create(Ticket item)
        {
            dbContext.Tickets.Add(item);
            dbContext.SaveChanges();
        }

        public void Delete(Ticket item)
        {
            dbContext.Tickets.Remove(item);
            dbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            var item = dbContext.Tickets.Find(id);
            dbContext.Tickets.Remove(item);
            dbContext.SaveChanges();
        }

        public Ticket Get(string id)
        {
            return dbContext.Tickets.Find(id);
        }

        public IEnumerable<Ticket> GetAll()
        {
            return dbContext.Tickets;
        }

        public void Update(Ticket item, Ticket newItem)
        {
            //TODO: add update
        }
    }
}
