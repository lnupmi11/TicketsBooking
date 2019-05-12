using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TicketsBooking.BLL.Interfaces;
using TicketsBooking.DAL.Entities;
using TicketsBooking.DAL.Interfaces;
using TicketsBooking.DTO.Ticket;

namespace TicketsBooking.BLL.Services
{
    public class BoughtTicketService : IServiceBoughtTicket
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public BoughtTicketService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Create(BoughtTicketDTO boughtTicketDTO)
        {
            if (boughtTicketDTO != null)
            {
                var boughtTicket = _mapper.Map<BoughtTicket>(boughtTicketDTO);
                _unitOfWork.BoughtTicketRepository.Create(boughtTicket);
            }
        }

        public void Delete(int id)
        {
            _unitOfWork.BoughtTicketRepository.Delete(id.ToString());
        }

        public BoughtTicketDTO Get(int id)
        {
            var boughtTicket = _unitOfWork.BoughtTicketRepository.Get(id.ToString());
            var boughtTicketDTO = _mapper.Map<BoughtTicketDTO>(boughtTicket);

            return boughtTicketDTO;
        }

        public IEnumerable<BoughtTicketDTO> GetAll()
        {
            var boughtTickets = _unitOfWork.BoughtTicketRepository.GetAll();
            var boughtTicketDTO = new List<BoughtTicketDTO>();

            foreach (var item in boughtTickets)
            {
                var boughtTicket = _mapper.Map<BoughtTicketDTO>(item);
                boughtTicketDTO.Add(boughtTicket);
            }

            return boughtTicketDTO;
        }

        public void Update(BoughtTicketDTO boughtTicketDTO)
        {
            var boughtTickets = _mapper.Map<Flight>(boughtTicketDTO);
            _unitOfWork.FlightRepository.Update(boughtTickets);
            _unitOfWork.SaveChanges();
        }
    }
}
