using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TicketsBooking.Controllers
{
    public class TicketController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
    }
}
