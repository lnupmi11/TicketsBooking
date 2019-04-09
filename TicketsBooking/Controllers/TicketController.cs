using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketsBooking.Models;
using TicketsBooking.Data;

namespace TicketsBooking.Controllers
{
    public class TicketController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }

        public IActionResult AddTicket(Ticket ticket)
        {
            using (Context db = new Context())
            {
                db.Add(ticket);
                db.SaveChanges();
            }
            return View();
        }

        public void DeleteTicket(Ticket ticket)
        {
            using (Context db = new Context())
            {
                db.Tickets.Remove(ticket);
            }
        }

        public List<Ticket> GetTicketsByFromTo(City from, City to)
        {
            var result = new List<Ticket>();

            using (Context db = new Context())
            {
                foreach(Ticket ticket in db.Tickets)
                {
                    if ((ticket.From.Id == from.Id) && (ticket.To.Id == to.Id))
                    {
                        result.Add(ticket);
                    }
                }
            }

            return result;
        }
    }
}