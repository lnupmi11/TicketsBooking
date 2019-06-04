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
    public class BoughtTicketServiceTest
    {
        private readonly IServiceBoughtTicket boughtTicketService;
        private TicketsBookingUnitOfWork unitOfWork;
        private Mock<IRepository<BoughtTicket>> boughtTicketMockRepository;
        private Mock<IMapper> mapper;

        public BoughtTicketServiceTest()
        {
            mapper = new Mock<IMapper>();
            unitOfWork = new TicketsBookingUnitOfWork(null);
            boughtTicketMockRepository = new Mock<IRepository<BoughtTicket>>();
            unitOfWork.BoughtTicketRepository = boughtTicketMockRepository.Object;
            boughtTicketService = new BoughtTicketService(unitOfWork, mapper.Object);

            Initialize();
        }


        [Fact]
        public void CreateTest()
        {
            //Arrange
            User user = new User
            {
                Id = "1",
                Email = "oleg@user.com"
            };
            var boughtTicket = new BoughtTicket { Id = 1, Price = 273, LocationFrom = "Lviv", LocationTo = "London", User = user };
            var boughtTicketDTO = new BoughtTicketDTO { Id = 1, Price = 273, LocationFrom = "Lviv", LocationTo = "London" };

            List<BoughtTicket> boughtTickets = new List<BoughtTicket>();

            boughtTicketMockRepository.Setup(x => x.GetAll()).Returns(boughtTickets);
            boughtTicketMockRepository.Setup(x => x.Create(boughtTicket)).Callback((BoughtTicket t) => { boughtTickets.Add(new BoughtTicket()); });
            mapper.Setup(x => x.Map<BoughtTicket>(boughtTicketDTO)).Returns(boughtTicket);

            boughtTicketService.Create(boughtTicketDTO);

            Assert.Single(boughtTicketService.GetAll());
        }

        [Fact]
        public void DeleteTest()
        {
            //Arrange
            List<BoughtTicket> boughtTickets = new List<BoughtTicket>();
            User user = new User
            {
                Id = "1",
                Email = "oleg@user.com"
            };
            var boughtTicket1 = new BoughtTicket { Id = 1, Price = 273, LocationFrom = "Lviv", LocationTo = "London", User = user };
            var boughtTicket2 = new BoughtTicket { Id = 2, Price = 150, LocationFrom = "Lviv", LocationTo = "London", User = user };

            boughtTickets.Add(boughtTicket1);
            boughtTickets.Add(boughtTicket2);

            var boughtTicketDTO = new BoughtTicketDTO { Id = 1, Price = 273, LocationFrom = "Lviv", LocationTo = "London" };

            //Act
            boughtTicketMockRepository.Setup(x => x.GetAll()).Returns(boughtTickets);
            boughtTicketMockRepository.Setup(x => x.Delete(boughtTicket1.Id.ToString()));
            mapper.Setup(x => x.Map<BoughtTicketDTO>(boughtTicket1)).Returns(boughtTicketDTO);

            boughtTicketService.Delete(boughtTicket1.Id);


            //Assert
            Assert.Null(boughtTicketService.Get(boughtTicket1.Id));
        }

        [Fact]
        public void GetAllTest()
        {
            //Arrange
            var testCollection = GetBoughtTicketCollection();

            //Act
            var actualCollection = boughtTicketService.GetAll();

            //Assert
            Assert.Equal(testCollection.Count(), actualCollection.Count());

        }

        private void Initialize()
        {
            mapper.Setup(x => x.Map<BoughtTicketDTO>(GetBoughtTicketCollection().ToList()[0])).Returns(GetBoughtTicketCollectionDTO().ToList()[0]);
            mapper.Setup(x => x.Map<BoughtTicketDTO>(GetBoughtTicketCollection().ToList()[1])).Returns(GetBoughtTicketCollectionDTO().ToList()[1]);
            mapper.Setup(x => x.Map<BoughtTicketDTO>(GetBoughtTicketCollection().ToList()[2])).Returns(GetBoughtTicketCollectionDTO().ToList()[2]);
            mapper.Setup(x => x.Map<BoughtTicketDTO>(GetBoughtTicketCollection().ToList()[3])).Returns(GetBoughtTicketCollectionDTO().ToList()[3]);


            boughtTicketMockRepository.Setup(x => x.GetAll()).Returns(GetBoughtTicketCollection());
        }

        private IEnumerable<BoughtTicket> GetBoughtTicketCollection()
        {
            User user = new User
            {
                Id = "1",
                Email = "oleg@user.com"
            };
            return new[]
            {
                new BoughtTicket { Id = 1,  Price = 273,  LocationFrom = "Lviv", LocationTo = "London", User = user },
                new BoughtTicket { Id = 2, Price = 112, LocationTo = "NY", LocationFrom = "London", User = user},
                new BoughtTicket { Id = 3, Price = 231, LocationTo = "London", LocationFrom = "NY", User = user },
                new BoughtTicket { Id = 4, Price = 221, LocationTo = "London" , LocationFrom = "Lviv", User = user }
            };
        }

        private IEnumerable<BoughtTicketDTO> GetBoughtTicketCollectionDTO()
        {
            return new[]
            {
                new BoughtTicketDTO { Id = 1,  Price = 273, LocationFrom = "Lviv", LocationTo = "London" },
                new BoughtTicketDTO { Id = 2, Price = 112, LocationTo = "NY", LocationFrom = "London" },
                new BoughtTicketDTO { Id = 3, Price = 231, LocationTo = "London", LocationFrom = "NY" },
                new BoughtTicketDTO { Id = 4, Price = 221, LocationTo = "London" , LocationFrom = "Lviv" }
            };
        }
    }
}
