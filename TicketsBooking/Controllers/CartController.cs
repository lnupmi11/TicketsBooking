using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketsBooking.BLL.Interfaces;
using TicketsBooking.DTO.Ticket;

namespace TicketsBooking.Controllers
{
    public class CartController : Controller
    {
        IOrderService _orderService;

        public CartController(IOrderService orderService) : base()
        {
            _orderService = orderService;
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
            //var userName = User.Identity.
            //_orderService.AddItemToBasket(userName, itemId);
            return new EmptyResult();
        }

        [Authorize]
        public IActionResult RemoveItem(string itemId)
        {
            var userName = User.Identity.Name;
            _orderService.DeleteItemFromBasket(userName, itemId);
            return new EmptyResult();
        }
    }
}