using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketsBooking.BLL.Interfaces;
using TicketsBooking.DAL.Interfaces;
using TicketsBooking.DTO.Ticket;
using TicketsBooking.Models;

namespace TicketsBooking.Controllers
{
    public class AdminController : Controller
    {
        private IServiceTicket _ticketService;
        private IOrderService _orderService;
        private IServiceFlight _flightService;
        private IServiceUser _serviceUser;
        private IUnitOfWork _unitOfWork;
    
        public AdminController(IUnitOfWork unitOfWork, IServiceTicket ticketService, IOrderService orderService, IServiceFlight serviceFlight, IServiceUser serviceUser) : base()
        {
            _ticketService = ticketService;
            _orderService = orderService;
            _flightService = serviceFlight;
            _serviceUser = serviceUser;
            _unitOfWork = unitOfWork;
        }
        public IActionResult AddTicket()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult GetAllTickets()
        {
            var flights = _flightService.GetAll();

            var tickets = new List<TicketViewModel>();
            foreach (var iteam in flights)
            {
                var itemTickets = _ticketService.GetAll().Where(x => x.FlightID == iteam.Id).ToList();
                foreach (var ticket in itemTickets)
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

        //TODO: available for admin only
        [Authorize]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteTicket(int id)
        {
            _ticketService.Delete(id);
            return RedirectToAction("GetAllTickets", "Admin");
        }

        [Authorize]
        [Authorize(Roles = "Admin")]
        public IActionResult EditTicket(int id)
        {
            var ticket = _ticketService.Get(id);
            var flight = _flightService.Get(ticket.FlightID);
            var viewTicket = new TicketViewModel()
            {
                Id = ticket.Id,
                Price = ticket.Price,
                FlightArrivingDate = flight.FlightArrivingDate,
                FlightDepartmentDate = flight.FlightDepartmentDate,
                LocationFrom = flight.LocationFrom,
                LocationTo = flight.LocationTo,
                Type = ticket.Type,
                FlightId = flight.Id
            };
            return View(viewTicket);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult UpdateTicket(TicketDTO ticket)
        {
            _ticketService.Update(ticket);

            return RedirectToAction("GetAllTickets", "Admin");
        }
    }
}