using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketsBooking.BLL.Interfaces;
using TicketsBooking.DAL.Interfaces;
using TicketsBooking.DTO.Ticket;
using TicketsBooking.Models;
using DinkToPdf;
using DinkToPdf.Contracts;
using TicketsBooking.Utility;
using Microsoft.EntityFrameworkCore;
using TicketsBooking.DAL.Entities;

namespace TicketsBooking.Controllers
{
    public class CartController : Controller
    {
        IOrderService _orderService;
        IServiceTicket _serviceTicket;
        private IUnitOfWork _unitOfWork;
        private IConverter _converter;

        public CartController(IUnitOfWork unitOfWork, IOrderService orderService, 
            IServiceTicket serviceTicket, IConverter converter) : base()
        {
            _orderService = orderService;
            _serviceTicket = serviceTicket;
            _unitOfWork = unitOfWork;
            _converter = converter;
        }

        [Authorize]
        public IActionResult Index()
        {
            var user = _unitOfWork.UserRepository.GetAll().Where(t => t.Email == User.Identity.Name).First();
            var cartItems = new List<TicketViewModel>();
            if (!string.IsNullOrEmpty(User.Identity.Name))
            {
                var ticketDTOs = _orderService.GetAllUserBasketItems(user.Id.ToString()).ToList();
                foreach (var item in ticketDTOs)
                {
                    var flight = _unitOfWork.FlightRepository.Get(t => t.Id == item.FlightID);
                    var viewTicket = new TicketViewModel()
                    {
                        Id = item.Id,
                        Price = item.Price,
                        FlightArrivingDate = flight.FlightArrivingDate,
                        FlightDepartmentDate = flight.FlightDepartmentDate,
                        LocationFrom = flight.LocationFrom,
                        LocationTo = flight.LocationTo
                    };
                    cartItems.Add(viewTicket);
                }
            }
            return View(cartItems);
        }

        [Authorize]
        public IActionResult RemoveItem(int id)
        {
            var userName = User.Identity.Name;
            _orderService.DeleteItemFromBasket(userName, id.ToString());
            return RedirectToAction("Index", "Cart");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Buy(int id)
        {
            var ticket = _unitOfWork.TicketRepository.Get(id.ToString());
            var flight = _unitOfWork.FlightRepository.GetAll().Where(t => t.Id == ticket.FlightId).FirstOrDefault();
            var user = _unitOfWork.UserRepository.GetAll().Where(t => t.Email == User.Identity.Name).First();

            var viewTicket = new TicketViewModel()
            {
                Id = ticket.Id,
                Price = ticket.Price,
                FlightArrivingDate = flight.FlightArrivingDate,
                FlightDepartmentDate = flight.FlightDepartmentDate,
                LocationFrom = flight.LocationFrom,
                LocationTo = flight.LocationTo
            };

            var listTicket = new List<TicketViewModel>();

            listTicket.Add(viewTicket);

            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
                Out = @"C:\Ticket.pdf"
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = TemplateGenerator.GetHTMLString(listTicket),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            //_converter.Convert(pdf);

            var boughtTicket = new BoughtTicket()
            {
                LocationFrom = viewTicket.LocationFrom,
                LocationTo = viewTicket.LocationTo,
                Price = viewTicket.Price,
                User = user
            };


            _unitOfWork.BoughtTicketRepository.Create(boughtTicket);

            _unitOfWork.TicketRepository.Delete(ticket.Id.ToString());

            return RedirectToAction("Index", "Cart");
        }

    }
}