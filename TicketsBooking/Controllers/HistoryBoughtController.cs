using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using TicketsBooking.BLL.Interfaces;
using TicketsBooking.DAL.Interfaces;

namespace TicketsBooking.Controllers
{
    public class HistoryBoughtController : Controller
    {
        IOrderService _orderService;
        IServiceTicket _serviceTicket;
        private IUnitOfWork _unitOfWork;

        public HistoryBoughtController(IUnitOfWork unitOfWork, IOrderService orderService,
            IServiceTicket serviceTicket) : base()
        {
            _orderService = orderService;
            _serviceTicket = serviceTicket;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {

            return View();
        }
    }
}