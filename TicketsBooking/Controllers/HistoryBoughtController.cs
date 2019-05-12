using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using TicketsBooking.BLL.Interfaces;
using TicketsBooking.DAL.Interfaces;

namespace TicketsBooking.Controllers
{
    public class HistoryBoughtController : Controller
    {
        IServiceBoughtTicket _serviceBoughtTicket;

        public HistoryBoughtController(IServiceBoughtTicket serviceBoughtTicket) : base()
        {
            _serviceBoughtTicket = serviceBoughtTicket;
        }
        public IActionResult Index()
        {

            return View();
        }
    }
}