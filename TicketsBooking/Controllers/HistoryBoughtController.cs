using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketsBooking.BLL.Interfaces;
using TicketsBooking.DAL.Interfaces;
using AutoMapper;
using TicketsBooking.DTO.Ticket;

namespace TicketsBooking.Controllers
{
    public class HistoryBoughtController : Controller
    {
        IServiceBoughtTicket _serviceBoughtTicket;
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public HistoryBoughtController(IServiceBoughtTicket serviceBoughtTicket, IUnitOfWork unitOfWork, IMapper mapper) : base()
        {
            _serviceBoughtTicket = serviceBoughtTicket;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var tickets = _unitOfWork.BoughtTicketRepository.GetQuery().Include(t => t.User).Where(t => t.User.Email == User.Identity.Name);
            var boughtTicketDTO = new List<BoughtTicketDTO>();
            foreach (var item in tickets)
            {
                var boughtTicket = _mapper.Map<BoughtTicketDTO>(item);
                boughtTicketDTO.Add(boughtTicket);
            }
            return View(boughtTicketDTO);
        }
    }
}