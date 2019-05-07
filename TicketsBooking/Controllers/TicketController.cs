using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketsBooking.BLL.Interfaces;
using TicketsBooking.DTO.Ticket;
using TicketsBooking.Models;

namespace TicketsBooking.Controllers
{
    public class TicketController : Controller
    {
        private IServiceTicket _ticketService;
        private IOrderService _orderService;
        private IServiceFlight _flightService;
        public TicketController(IServiceTicket ticketService, IOrderService orderService, IServiceFlight serviceFlight) : base()
        {
            _ticketService = ticketService;
            _orderService = orderService;
            _flightService = serviceFlight;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search(FlightViewModel flightViewModel)
        {
            var flights = _flightService.GetAll().Where(t => t.LocationFrom == flightViewModel.cityFrom).Where(t => t.LocationTo == flightViewModel.cityTo).
                Where(t => t.FlightDepartmentDate == flightViewModel.dateTime);

            if (flights != null)
            {
                var tickets = new List<TicketDTO>();
                foreach (var iteam in flights)
                {
                    tickets.Add(_ticketService.Get(iteam.Id));
                }
                return View(tickets);
            }

            return View();
        }

        public IActionResult AddToCart(int id)
        {
            //_orderService.AddItemToBasket(_serviceUser.GetByName(User.Identity.Name).Basket.Id.ToString(), id.ToString());

            return RedirectToAction("Index");
        }


    }
}