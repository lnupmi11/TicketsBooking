﻿using TicketsBooking.DAL.EntityFramework;
using TicketsBooking.DAL.Interfaces;
using TicketsBooking.DAL.Entities;
using TicketsBooking.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketsBooking.DAL.UnitOfWork
{
    public class TicketsBookingUnitOfWork : IUnitOfWork
    {
        private TicketsBookingContext _context;

        IRepository<Flight> _flightRepository;
        IRepository<Basket> _basketRepository;
        IRepository<TicketType> _ticketTypeRepository;
        IRepository<Ticket> _ticketRepository;
        IRepository<User> _userRepository;
        IRepository<BoughtTicket> _boughtTicketRepository;
        IRepository<Like> _likeRepository;

        //IRepository<User> _userRepository;

        public TicketsBookingUnitOfWork(TicketsBookingContext context)
        {
            _context = context;
        }

        public IRepository<Like> LikeRepository
        {
            get
            {
                if (_likeRepository == null)
                {
                    _likeRepository = new GenericRepository<Like>(_context);
                }
                return _likeRepository;
            }
            set
            {
                this._likeRepository = value ?? new GenericRepository<Like>(_context);
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
            set
            {
                this._ticketRepository = value ?? new GenericRepository<Ticket>(_context);
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
            set
            {
                this._flightRepository = value ?? new GenericRepository<Flight>(_context);
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
            set
            {
                this._userRepository =  value ?? new GenericRepository<User>(_context);
            }
        }

        public IRepository<BoughtTicket> BoughtTicketRepository
        {
            get
            {
                if (_boughtTicketRepository == null)
                {
                    _boughtTicketRepository = new GenericRepository<BoughtTicket>(_context);
                }
                return _boughtTicketRepository;
            }
            set
            {
                this._boughtTicketRepository = value ?? new GenericRepository<BoughtTicket>(_context);
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
