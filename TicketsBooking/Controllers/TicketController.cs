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
        private IServiceUser _serviceUser;
        public TicketController(IServiceTicket ticketService, IOrderService orderService, IServiceFlight serviceFlight, IServiceUser serviceUser) : base()
        {
            _ticketService = ticketService;
            _orderService = orderService;
            _flightService = serviceFlight;
            _serviceUser = serviceUser;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search(FlightViewModel flightViewModel)
        {
            var flights = _flightService.GetAll().Where(t => t.LocationFrom == flightViewModel.cityFrom).Where(t => t.LocationTo == flightViewModel.cityTo);

            var tickets = new List<TicketViewModel>();
            foreach (var iteam in flights)
            {
                var ticket = _ticketService.Get(iteam.Id);
                if(ticket != null)
                {
                    var viewTicket = new TicketViewModel()
                    {
                        Id = ticket.Id,
                        Price = ticket.Price,
                        FlightArrivingDate = iteam.FlightArrivingDate,
                        FlightDepartmentDate = iteam.FlightDepartmentDate,
                        LocationFrom = iteam.LocationFrom,
                        LocationTo = iteam.LocationTo
                    };
                    tickets.Add(viewTicket);
                }
            }
            if (tickets.Count != 0)
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