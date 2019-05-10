using System;
using System.Collections.Generic;
using System.Text;
using TicketsBooking.BLL.Interfaces;
using TicketsBooking.DAL.Entities;
using TicketsBooking.DAL.EntityFramework;
using TicketsBooking.DAL.Repositories;
using TicketsBooking.DTO.Ticket;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TicketsBooking.DAL.Interfaces;
using AutoMapper;

namespace TicketsBooking.BLL.Services
{
    public class TicketService : IServiceTicket
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public TicketService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Create(TicketDTO ticketDTO)
        {
            if (ticketDTO != null)
            {
                var ticket = _mapper.Map<Ticket>(ticketDTO);
                _unitOfWork.TicketRepository.Create(ticket);
            }
        }

        public void Delete(int id)
        {
            _unitOfWork.TicketRepository.Delete(id.ToString());
        }

        public TicketDTO Get(int id)
        {
            var ticket = _unitOfWork.TicketRepository.Get(id.ToString());
            var ticketDTO = _mapper.Map<TicketDTO>(ticket);

            return ticketDTO;
        }

        public IEnumerable<TicketDTO> GetAll()
        {
            var tickets = _unitOfWork.TicketRepository.GetAll();
            var ticketsDTO = new List<TicketDTO>();

            foreach (var item in tickets)
            {
                var ticket = _mapper.Map<TicketDTO>(item);
                ticketsDTO.Add(ticket);
            }

            return ticketsDTO;
        }

        public void Update(TicketDTO ticketDTO)
        {
            var ticket = _mapper.Map<Ticket>(ticketDTO);
            _unitOfWork.TicketRepository.Update(ticket);
            _unitOfWork.SaveChanges();
        }
    }
}
