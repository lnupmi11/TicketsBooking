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

namespace TicketsBooking.Tests
{
    public class TicketServiceTest
    {
        private readonly IServiceTicket ticketService;
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
            var ticket = new Ticket() { Price = 400, FlightId = 1 };
            var ticketDTO = new TicketDTO() { Price = 400, FlightID = 1 };

            List<Ticket> tickets = new List<Ticket>();

            ticketMockRepository.Setup(x => x.GetAll()).Returns(tickets);
            ticketMockRepository.Setup(x => x.Create(ticket)).Callback((Ticket t) => { tickets.Add(new Ticket()); });
            mapper.Setup(x => x.Map<Ticket>(ticketDTO)).Returns(ticket);

            ticketService.Create(ticketDTO);

            Assert.Single(ticketService.GetAll());
        }

        [Fact]
        public void DeleteTest()
        {
            //Arrange
            List<Ticket> tickets = new List<Ticket>();
            var ticket1 = new Ticket() { Id = 1, Price = 400, FlightId = 1 };
            var ticket2 = new Ticket() { Id = 2, Price = 200, FlightId = 2 };
            tickets.Add(ticket1);
            tickets.Add(ticket2);

            //Act
            ticketMockRepository.Setup(x => x.GetAll()).Returns(tickets);
            ticketMockRepository.Setup(x => x.Delete(ticket1.Id.ToString()));
            mapper.Setup(x => x.Map<Ticket>(ticket1)).Returns(ticket1);

            ticketService.Delete(ticket1.Id);


            //Assert
            Assert.Null(ticketService.Get(ticket1.Id));
        }

        [Fact]
        public void GetAllTest()
        {
            //Arrange
            var testCollection = GetTicketCollection();

            //Act
            var actualCollection = ticketService.GetAll();

            //Assert
            Assert.Equal(testCollection.Count(), actualCollection.Count());

        }

        [Fact]
        public void GetTicketTest()
        {
            //Arrange
            int index = 1;
            var testTicket = GetTicketCollection().ElementAt(index);

            //Act            
            ticketMockRepository.Setup(x => x.Get(index.ToString())).Returns(GetTicketCollection().ElementAt(index));
            mapper.Setup(x => x.Map<TicketDTO>(It.IsAny<Ticket>())).Returns(GetTicketCollectionDTO().ElementAt(index));
            var actualTicket = ticketService.Get(index);

            //Assert
            Assert.Equal(testTicket.Id, actualTicket.Id);
            Assert.Equal(testTicket.Price, actualTicket.Price);
            Assert.Equal(testTicket.Type.Id, actualTicket.Type.Id);
        }

        [Fact]
        public void UpdateTicketTest()
        {

            //Arrange
            int index = 1;
            var testTicket = GetTicketCollection().ElementAt(index);

            //Act            
            ticketMockRepository.Setup(x => x.Get(index.ToString())).Returns(GetTicketCollection().ElementAt(index));
            mapper.Setup(x => x.Map<TicketDTO>(It.IsAny<Ticket>())).Returns(GetTicketCollectionDTO().ElementAt(index));
            var actualTicket = ticketService.Get(index);
        }

        //Test data

        private void Initialize()
        {
            mapper.Setup(x => x.Map<TicketDTO>(GetTicketCollection().ToList()[0])).Returns(GetTicketCollectionDTO().ToList()[0]);
            mapper.Setup(x => x.Map<TicketDTO>(GetTicketCollection().ToList()[1])).Returns(GetTicketCollectionDTO().ToList()[1]);
            mapper.Setup(x => x.Map<TicketDTO>(GetTicketCollection().ToList()[2])).Returns(GetTicketCollectionDTO().ToList()[2]);
            mapper.Setup(x => x.Map<TicketDTO>(GetTicketCollection().ToList()[3])).Returns(GetTicketCollectionDTO().ToList()[3]);
            mapper.Setup(x => x.Map<TicketDTO>(GetTicketCollection().ToList()[4])).Returns(GetTicketCollectionDTO().ToList()[4]);
            mapper.Setup(x => x.Map<TicketDTO>(GetTicketCollection().ToList()[5])).Returns(GetTicketCollectionDTO().ToList()[5]);


            ticketMockRepository.Setup(x => x.GetAll()).Returns(GetTicketCollection());
        }

        private IEnumerable<Ticket> GetTicketCollection()
        {
            var ticketType = new TicketType() { TypeName = "econom" };
            return new[]
            {
                new Ticket { Id = 1,  Price = 273, Type = ticketType },
                new Ticket { Id = 2, Price = 112, Type = ticketType },
                new Ticket { Id = 3, Price = 231, Type = ticketType },
                new Ticket { Id = 4, Price = 221, Type = ticketType },
                new Ticket { Id = 5, Price = 100, Type = ticketType },
                new Ticket { Id = 6, Price = 321, Type = ticketType }
            };
        }

        private IEnumerable<TicketDTO> GetTicketCollectionDTO()
        {
            var ticketType = new TicketTypeDTO() { TypeName = "econom" };
            return new[]
            {
                new TicketDTO { Id = 1,  Price = 273, Type = ticketType },
                new TicketDTO { Id = 2, Price = 112, Type = ticketType },
                new TicketDTO { Id = 3, Price = 231, Type = ticketType },
                new TicketDTO { Id = 4, Price = 221, Type = ticketType },
                new TicketDTO { Id = 5, Price = 100, Type = ticketType },
                new TicketDTO { Id = 6, Price = 321, Type = ticketType }
            };
        }

    }
}