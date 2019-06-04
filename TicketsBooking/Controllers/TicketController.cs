using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketsBooking.BLL.Interfaces;
using TicketsBooking.DAL.Entities;
using TicketsBooking.DAL.Interfaces;
using TicketsBooking.DTO.Ticket;
using TicketsBooking.Models;
using X.PagedList;

namespace TicketsBooking.Controllers
{
    public class TicketController : Controller
    {
        private IServiceTicket _ticketService;
        private IOrderService _orderService;
        private IServiceFlight _flightService;
        private IServiceUser _serviceUser;
        private IUnitOfWork _unitOfWork;
        public TicketController(IUnitOfWork unitOfWork, IServiceTicket ticketService, IOrderService orderService, IServiceFlight serviceFlight, IServiceUser serviceUser) : base()
        {
            _ticketService = ticketService;
            _orderService = orderService;
            _flightService = serviceFlight;
            _serviceUser = serviceUser;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search(FlightViewModel flightViewModel)
        {
            var flights = _flightService.GetAll().Where(t => t.LocationFrom == flightViewModel.cityFrom).
                Where(t => t.LocationTo == flightViewModel.cityTo).
                Where(t => t.FlightDepartmentDate.Year == flightViewModel.dateTime.Year).
                Where(t => t.FlightDepartmentDate.Month == flightViewModel.dateTime.Month).
                Where(t => t.FlightDepartmentDate.Day == flightViewModel.dateTime.Day);

            //flights = flights.OrderBy(t => t.Tickets.Max(k=>k.Price)).ToList();

            var tickets = new List<TicketViewModel>();
            foreach (var iteam in flights)
            {
                var likes = _unitOfWork.LikeRepository.GetAll().Where(t => t.FlightId == iteam.Id);

                var listTicket = _unitOfWork.TicketRepository.GetQuery().Include(t => t.Basket).Where(t => t.Basket == null).Where(t => t.FlightId == iteam.Id);

                foreach (var ticket in listTicket)
                {
                    if (ticket.FlightId == iteam.Id)
                    {
                        var viewTicket = new TicketViewModel()
                        {
                            Id = ticket.Id,
                            Price = ticket.Price,
                            FlightArrivingDate = iteam.FlightArrivingDate,
                            FlightDepartmentDate = iteam.FlightDepartmentDate,
                            LocationFrom = iteam.LocationFrom,
                            LocationTo = iteam.LocationTo,
                            CollLike = likes.Count()
                        };
                        tickets.Add(viewTicket);
                    }

                }
            }
            if (tickets.Count != 0)
            {
                //tickets = tickets.OrderBy(t => t.Price).ThenBy(t => t.FlightArrivingDate).ToList();
                //return View(new ListObj { ticketViews = tickets } );
                return View(tickets);
            }
            return View();
        }

        public IActionResult AddToCart(int id)
        {

            _orderService.AddItemToBasket(User.Identity.Name, id.ToString());

            return RedirectToAction("Index");
        }


        public IActionResult GetAllTickets(int? pg)
        {
            int pageSize = 3;
            int pageNumber = (pg ?? 1);
            var flights = _unitOfWork.FlightRepository.GetQuery().Include(t => t.Tickets);
            var tickets = new List<TicketViewModel>();
            foreach (var iteam in flights)
            {
                foreach (var ticket in iteam.Tickets)
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

            var listTickets = tickets.ToPagedList(pageNumber, pageSize);

            ViewBag.listTickets = listTickets;

            return View();
        }

        public IActionResult SortByDate (int? pg)
        {
            int pageSize = 3;
            int pageNumber = (pg ?? 1);
            var flights = _unitOfWork.FlightRepository.GetQuery().Include(t => t.Tickets);
            var tickets = new List<TicketViewModel>();
            foreach (var iteam in flights)
            {
                foreach (var ticket in iteam.Tickets)
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

            var listTickets = tickets.OrderBy(t => t.FlightDepartmentDate).ToList();
            var listTicketsResult = listTickets.ToPagedList(pageNumber, pageSize);
            ViewBag.listTickets = listTicketsResult;

            return View();
        }

        public IActionResult AddLike(int id)
        {
            var tiket = _unitOfWork.TicketRepository.GetAll().Where(t => t.Id == id).FirstOrDefault();
            var like = _unitOfWork.LikeRepository.GetAll().Where(t => t.UserEmail == User.Identity.Name).Where(k=>k.FlightId == tiket.FlightId).FirstOrDefault();
            if (like == null)
            {
                Like likeDTO = new Like
                {
                    UserEmail = User.Identity.Name,
                    FlightId = tiket.FlightId
                };
                _unitOfWork.LikeRepository.Create(likeDTO);
            }
            return RedirectToAction("Index");
        }


    }
}