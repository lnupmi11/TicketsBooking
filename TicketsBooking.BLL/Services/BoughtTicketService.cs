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
                var flight = _mapper.Map<BoughtTicket>(boughtTicketDTO);
                _unitOfWork.FlightRepository.Create(flight);
            }
        }

        public void Delete(int id)
        {
            _unitOfWork.FlightRepository.Delete(id.ToString());
        }

        public BoughtTicketDTO Get(int id)
        {
            var flight = _unitOfWork.FlightRepository.Get(id.ToString());
            var flightDTO = _mapper.Map<BoughtTicketDTO>(flight);

            return flightDTO;
        }

        public IEnumerable<BoughtTicketDTO> GetAll()
        {
            var flights = _unitOfWork.FlightRepository.GetAll();
            var flightDTO = new List<BoughtTicketDTO>();

            foreach (var item in flights)
            {
                var flight = _mapper.Map<BoughtTicketDTO>(item);
                flightDTO.Add(flight);
            }

            return flightDTO;
        }

        public void Update(BoughtTicketDTO flightDTO)
        {
            var flight = _mapper.Map<Flight>(flightDTO);
            _unitOfWork.FlightRepository.Update(flight);
            _unitOfWork.SaveChanges();
        }
    }
}
