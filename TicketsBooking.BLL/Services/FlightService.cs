using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TicketsBooking.BLL.Interfaces;
using TicketsBooking.DAL.Entities;
using TicketsBooking.DAL.Interfaces;
using TicketsBooking.DTO.Flight;

namespace TicketsBooking.BLL.Services
{
    public class FlightService : IServiceFlight
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public FlightService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Create(FlightDTO flightDTO)
        {
            if (flightDTO != null)
            {
                var flight = _mapper.Map<Flight>(flightDTO);
                _unitOfWork.FlightRepository.Create(flight);
            }
        }

        public void Delete(int id)
        {
            _unitOfWork.FlightRepository.Delete(id.ToString());
        }

        public FlightDTO Get(int id)
        {
            var flight = _unitOfWork.FlightRepository.Get(id.ToString());
            var flightDTO = _mapper.Map<FlightDTO>(flight);

            return flightDTO;
        }

        public IEnumerable<FlightDTO> GetAll()
        {
            var flights = _unitOfWork.FlightRepository.GetAll();
            var flightDTO = new List<FlightDTO>();

            foreach (var item in flights)
            {
                var flight = _mapper.Map<FlightDTO>(item);
                flightDTO.Add(flight);
            }

            return flightDTO;
        }

        public void Update(FlightDTO flightDTO)
        {
            var flight = _mapper.Map<Flight>(flightDTO);
            _unitOfWork.FlightRepository.Update(flight);
            _unitOfWork.SaveChanges();
        }
    }
}
