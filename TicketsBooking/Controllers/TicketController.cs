using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketsBooking.BLL.Interfaces;
using TicketsBooking.Models;

namespace TicketsBooking.Controllers
{
    public class TicketController : Controller
    {
        private IServiceTicket _ticketService;
        private IOrderService _orderService;
        private IServiceUser _serviceUser;
        public TicketController(IServiceTicket ticketService, IOrderService orderService) : base()
        {
            _ticketService = ticketService;
            _orderService = orderService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search(FlightViewModel flightViewModel)
        {
            var tickets = _ticketService.GetAll().Where(t => t.CityFrom == flightViewModel.cityFrom).Where(t => t.CityTo == flightViewModel.cityTo);

            if (tickets != null)
            {
                return View(tickets);
            }

            return View();
        }

        public IActionResult AddToCart(int id)
        {
            _orderService.AddItemToBasket(_serviceUser.GetByName(User.Identity.Name).Basket.Id.ToString(), id.ToString());

            return RedirectToAction("Index");
        }


    }
}