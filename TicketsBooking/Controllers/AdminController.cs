using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketsBooking.BLL.Interfaces;
using TicketsBooking.DAL.Interfaces;
using TicketsBooking.DTO.Flight;
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
            foreach (var item in flights)
            {
                var itemTickets = _ticketService.GetAll().Where(x => x.FlightID == item.Id).ToList();
                foreach (var ticket in itemTickets)
                {
                    var viewTicket = new TicketViewModel()
                    {
                        Id = ticket.Id,
                        Price = ticket.Price,
                        FlightArrivingDate = item.FlightArrivingDate,
                        FlightDepartmentDate = item.FlightDepartmentDate,
                        LocationFrom = item.LocationFrom,
                        LocationTo = item.LocationTo
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
        
        

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteTicket(int id)
        {
            _ticketService.Delete(id);
            return RedirectToAction("GetAllTickets", "Admin");
        }
        

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


        
        [Authorize(Roles = "Admin")]
        public IActionResult Flights()
        {
            var flights = _flightService.GetAll();

            var data = new List<FlightViewModel>();
            foreach (var item in flights)
            {
                var flight = new FlightViewModel()
                {
                    Id = item.Id,
                    cityFrom = item.LocationFrom,
                    cityTo = item.LocationTo,
                    dateTimeDeparture = item.FlightDepartmentDate,
                    dateTimeArriving = item.FlightArrivingDate
                };
                data.Add(flight);
                
            }
            if (data.Count != 0)
            {
                return View(data);
            }
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult EditFlight(int id)
        {            
            var flight = _flightService.Get(id);
            var viewFlight = new FlightViewModel()
            {
                Id = flight.Id,
                cityFrom = flight.LocationFrom,
                cityTo = flight.LocationTo,
                dateTimeDeparture = flight.FlightDepartmentDate,
                dateTimeArriving = flight.FlightArrivingDate
            };

            return View(viewFlight);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult UpdateFlight(FlightDTO flight)
        {
            _flightService.Update(flight);

            return RedirectToAction("Flights", "Admin");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteFlight(int id)
        {
            _flightService.Delete(id);
            return RedirectToAction("Flights", "Admin");
        }


    }

}