using System;
using System.Collections.Generic;
using System.Text;
using TicketsBooking.BLL.Interfaces;
using TicketsBooking.DAL.Entities;
using TicketsBooking.DAL.EntityFramework;
using TicketsBooking.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TicketsBooking.BLL.Services
{
    //ToDo
    //public class TicketService : IServiceTicket
    //{
    //    public void Create(Ticket ticket)
    //    {
    //        TicketRepository ticketRepository = new TicketRepository();
    //        ticketRepository.Create(ticket);
    //    }

    //    public void Delete(int id)
    //    {
    //        using (TicketsBookingContext db = new TicketsBookingContext())
    //        {
    //            TicketRepository ticketRepository = new TicketRepository();
    //            var ticket = db.Tickets.Where(t => t.Id == id).First();
    //            ticketRepository.Delete(ticket);
    //        }

    //    }

    //    public Ticket Get(int id)
    //    {
    //        TicketRepository ticketRepository = new TicketRepository();
    //        return ticketRepository.Get(id.ToString());

    //    }

    //    public IEnumerable<Ticket> GetAll()
    //    {
    //        TicketRepository ticketRepository = new TicketRepository();
    //        return ticketRepository.GetAll();
    //    }

    //    public void Update(Ticket ticket)
    //    {
    //        TicketRepository ticketRepository = new TicketRepository();
    //        ticketRepository.Update(ticket);
    //    }
    //}
}
