using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketsBooking.BLL.Interfaces;
using TicketsBooking.DAL.Interfaces;
using TicketsBooking.DTO.Ticket;
using TicketsBooking.Models;

namespace TicketsBooking.Controllers
{
    public class CartController : Controller
    {
        IOrderService _orderService;
        IServiceTicket _serviceTicket;
        private IUnitOfWork _unitOfWork;

        public CartController(IUnitOfWork unitOfWork, IOrderService orderService, IServiceTicket serviceTicket) : base()
        {
            _orderService = orderService;
            _serviceTicket = serviceTicket;
            _unitOfWork = unitOfWork;
        }

        [Authorize]
        public IActionResult Index()
        {
            var user = _unitOfWork.UserRepository.GetAll().Where(t => t.Email == User.Identity.Name).First();
            var cartItems = new List<TicketViewModel>();
            if (!string.IsNullOrEmpty(User.Identity.Name))
            {
                var ticketDTOs = _orderService.GetAllUserBasketItems(user.Id.ToString()).ToList();
                foreach(var item in ticketDTOs)
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
        public IActionResult Buy(int id)
        {
            
            _serviceTicket.Delete(id);
            
            return RedirectToAction("Index", "Home");
        }
    }
}