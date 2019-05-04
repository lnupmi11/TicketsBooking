using TicketsBooking.DAL.EntityFramework;
using TicketsBooking.DAL.Interfaces;
using TicketsBooking.DAL.Entities;
using TicketsBooking.DAL.Repositories;
using TicketsBooking.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketsBooking.DAL.UnitOfWork
{
    public class TicketsBookingUnitOfWork : IUnitOfWork
    {
        private TicketsBookingContext _context;

        IRepository<City> _cityRepository;
        IRepository<Flight> _flightRepository;
        IRepository<Basket> _basketRepository;
        IRepository<TicketType> _ticketTypeRepository;
        IRepository<Ticket> _ticketRepository;
        IRepository<User> _userRepository;

        //IRepository<User> _userRepository;

        public TicketsBookingUnitOfWork(TicketsBookingContext context)
        {
            _context = context;
        }

        public IRepository<City> CityRepository
        {
            get
            {
                if (_cityRepository == null)
                {
                    _cityRepository = new GenericRepository<City>(_context);
                }
                return _cityRepository;
            }
        }

        public IRepository<Ticket> TicketRepository
        {
            get
            {
                if (_ticketRepository == null)
                {
                    _ticketRepository = new GenericRepository<Ticket>(_context);
                }
                return _ticketRepository;
            }
        }

        public IRepository<Flight> FlightRepository
        {
            get
            {
                if (_flightRepository == null)
                {
                    _flightRepository = new GenericRepository<Flight>(_context);
                }
                return _flightRepository;
            }
        }
        public IRepository<Basket> BasketRepository
        {
            get
            {
                if (_basketRepository == null)
                {
                    _basketRepository = new GenericRepository<Basket>(_context);
                }
                return _basketRepository;
            }
        }
        public IRepository<TicketType> TicketTypeRepository
        {
            get
            {
                if (_ticketTypeRepository == null)
                {
                    _ticketTypeRepository = new GenericRepository<TicketType>(_context);
                }
                return _ticketTypeRepository;
            }

        }

        public IRepository<User> UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new GenericRepository<User>(_context);
                }
                return _userRepository;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
