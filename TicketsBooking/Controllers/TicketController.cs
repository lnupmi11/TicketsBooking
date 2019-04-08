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
    }
}