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
            var cartItems = new List<TicketDTO>();
            if (!string.IsNullOrEmpty(User.Identity.Name))
            {
                cartItems = _orderService.GetAllUserBasketItems(user.Id.ToString()).ToList();
            }
            return View(cartItems);
        }

        [Authorize]
        public IActionResult AddItem(string itemId)
        {
            var userName = User.Identity.Name;
            _orderService.AddItemToBasket(userName, itemId);
            return new EmptyResult();
        }

        [Authorize]
        public IActionResult RemoveItem(string itemId)
        {
            var userName = User.Identity.Name;
            _orderService.DeleteItemFromBasket(userName, itemId);
            return new EmptyResult();
        }

        [Authorize]
        public IActionResult Buy(List<string> itemIds)
        {
            foreach(var item in itemIds)
            {
                _serviceTicket.Delete(Int32.Parse(item));
            }
            return RedirectToAction("Index", "Home");
        }
    }
}