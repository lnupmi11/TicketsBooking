using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketsBooking.BLL.Interfaces;
using TicketsBooking.DTO.Ticket;
using TicketsBooking.Models;

namespace TicketsBooking.Controllers
{
    public class CartController : Controller
    {
        IOrderService _orderService;
        IServiceTicket _serviceTicket;

        public CartController(IOrderService orderService, IServiceTicket serviceTicket) : base()
        {
            _orderService = orderService;
            _serviceTicket = serviceTicket;
        }

        [Authorize]
        public IActionResult Index()
        {
            var userName = User.Identity.Name;
            var cartItems = new List<TicketDTO>();
            if (!string.IsNullOrEmpty(userName))
            {
                cartItems = _orderService.GetAllUserBasketItems(userName).ToList();
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