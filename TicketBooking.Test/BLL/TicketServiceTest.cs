using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;
using TicketsBooking.BLL.Services;
using TicketsBooking.DAL;
using TicketsBooking.DAL.Interfaces;
using TicketsBooking.DAL.Entities;
using TicketsBooking.DAL.EntityFramework;
using TicketsBooking.DAL.UnitOfWork;
using TicketsBooking.BLL.Interfaces;
using Xunit;
using AutoMapper;
using TicketsBooking.DTO.Ticket;

namespace TicketsBooking.Test.BLL
{
    public class TicketServiceTest
    {
        private readonly IServiceTicket  ticketService;
        private TicketsBookingUnitOfWork unitOfWork;
        private Mock<IRepository<Ticket>> ticketMockRepository;
        private Mock<IMapper> mapper;

        public TicketServiceTest()
        {
            mapper = new Mock<IMapper>();
            unitOfWork = new TicketsBookingUnitOfWork(null);
            ticketMockRepository = new Mock<IRepository<Ticket>>();
            unitOfWork.TicketRepository = ticketMockRepository.Object;
            ticketService = new TicketService(unitOfWork, mapper.Object);

            Initialize();
        }

        [Fact]
        public void CreateTest()
        {
            //Arrange
            var ticket = new Ticket(){ Price = 400, FlightId = 1};
            var ticketDTO = new TicketDTO(){ Price = 400, FlightID = 1 };

            List<Ticket> tickets = new List<Ticket>();

            ticketMockRepository.Setup(x => x.GetAll()).Returns(tickets);
            ticketMockRepository.Setup(x => x.Create(ticket)).Callback((Ticket t) => { tickets.Add(new Ticket()); });
            mapper.Setup(x => x.Map<Ticket>(ticketDTO)).Returns(ticket);

            ticketService.Create(ticketDTO);             

            Assert.Single(ticketService.GetAll());
        }



        //Test data

        private void Initialize()
        {
            mapper.Setup(x => x.Map<Ticket>(GetTicketCollection().ToList()[0])).Returns(GetTicketCollection().ToList()[0]);
            mapper.Setup(x => x.Map<Ticket>(GetTicketCollection().ToList()[1])).Returns(GetTicketCollection().ToList()[1]);
            mapper.Setup(x => x.Map<Ticket>(GetTicketCollection().ToList()[2])).Returns(GetTicketCollection().ToList()[2]);
            mapper.Setup(x => x.Map<Ticket>(GetTicketCollection().ToList()[3])).Returns(GetTicketCollection().ToList()[3]);
            mapper.Setup(x => x.Map<Ticket>(GetTicketCollection().ToList()[4])).Returns(GetTicketCollection().ToList()[4]);
            mapper.Setup(x => x.Map<Ticket>(GetTicketCollection().ToList()[5])).Returns(GetTicketCollection().ToList()[5]);
        }

        private IEnumerable<Ticket> GetTicketCollection()
        {
            var ticketType = new TicketType() { TypeName = "econom" };
            return new[]
            {
                new Ticket { Price = 273, Type = ticketType },
                new Ticket { Price = 112, Type = ticketType },
                new Ticket { Price = 231, Type = ticketType },
                new Ticket { Price = 221, Type = ticketType },
                new Ticket { Price = 100, Type = ticketType },
                new Ticket { Price = 321, Type = ticketType }
            };
        }
    }
}
