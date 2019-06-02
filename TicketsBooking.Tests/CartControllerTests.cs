using Microsoft.AspNetCore.Mvc;
using TicketsBooking.Controllers;
using TicketsBooking.Models;
using Moq;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using TicketsBooking.DAL.Interfaces;
using System;
using TicketsBooking.BLL.Interfaces;
using DinkToPdf.Contracts;
using TicketsBooking.DAL.Entities;
using TicketsBooking.DTO.Ticket;
using System.Security.Principal;
using Microsoft.AspNetCore.Http;

namespace TicketsBooking.Tests
{
    public class CartControllerTests
    {
        private readonly CartController cartController;
        private readonly Mock<IOrderService> mockIOrderService;
        private readonly Mock<IServiceTicket> mockIServiceTicket;
        private readonly Mock<IUnitOfWork> mockIUnitOfWork;
        private readonly Mock<IConverter> mockIConverter;
        public CartControllerTests()
        {
            mockIOrderService = new Mock<IOrderService>();
            mockIServiceTicket = new Mock<IServiceTicket>();
            mockIUnitOfWork = new Mock<IUnitOfWork>();
            mockIConverter = new Mock<IConverter>();

            cartController = new CartController(
                mockIUnitOfWork.Object, mockIOrderService.Object, mockIServiceTicket.Object,
                mockIConverter.Object);

        }


        [Fact]
        public async void IndexTest()
        {
            mockIUnitOfWork.Setup(m => m.UserRepository.GetAll()).Returns(GetTestUser());
            mockIOrderService.Setup(m => m.GetAllUserBasketItems('2'.ToString())).Returns(new List<TicketDTO>());
            mockIUnitOfWork.Setup(m => m.FlightRepository.Get('5'.ToString())).Returns(new Flight());

            var fakeHttpContext = new Mock<HttpContext>();
            var fakeIdentity = new GenericIdentity("oleg@google.com");
            var principal = new GenericPrincipal(fakeIdentity, null);

            fakeHttpContext.Setup(t => t.User).Returns(principal);

            cartController.ControllerContext.HttpContext = fakeHttpContext.Object;

            var result = cartController.Index();


            Assert.NotNull(result);
        }

        [Fact]
        public void RemoveItemTest()
        {
            int id = 1;

            var fakeHttpContext = new Mock<HttpContext>();
            var fakeIdentity = new GenericIdentity("oleg@google.com");
            var principal = new GenericPrincipal(fakeIdentity, null);

            fakeHttpContext.Setup(t => t.User).Returns(principal);

            cartController.ControllerContext.HttpContext = fakeHttpContext.Object;

            var result = cartController.RemoveItem(id);

            mockIOrderService.Verify(x => x.DeleteItemFromBasket("oleg@google.com", id.ToString()), Times.Exactly(1));

            Assert.NotNull(result);
        }

        [Fact]
        public void BuyTest()
        {
            int id = 1;

            var fakeHttpContext = new Mock<HttpContext>();
            var fakeIdentity = new GenericIdentity("oleg@google.com");
            var principal = new GenericPrincipal(fakeIdentity, null);

            fakeHttpContext.Setup(t => t.User).Returns(principal);

            cartController.ControllerContext.HttpContext = fakeHttpContext.Object;

            mockIUnitOfWork.Setup(m => m.UserRepository.GetAll()).Returns(GetTestUser());

            mockIUnitOfWork.Setup(m => m.TicketRepository.Get(id.ToString())).Returns(ticket);

            mockIUnitOfWork.Setup(m => m.FlightRepository.GetAll()).Returns(GetTestFlights);

            mockIUnitOfWork.Setup(m => m.BoughtTicketRepository.Create(boughtTicket));

            var result = cartController.Buy(id);

            mockIUnitOfWork.Verify(x => x.TicketRepository.Delete('1'.ToString()), Times.Exactly(1));

            Assert.NotNull(result);
        }

        private BoughtTicket boughtTicket = new BoughtTicket()
        {
            Id = 1,
            Price = 900,
            User = new User { Id = '1'.ToString(), Email = "oleg@google.com" },
            LocationFrom = "Lviv",
            LocationTo = "London"
        };

        private Ticket ticket = new Ticket()
        {
            Id = 1,
            Price = 900,
            FlightId = 1
        };

        private Flight flight = new Flight()
        {
            Id = 1,
            FlightDepartmentDate = Convert.ToDateTime("2019-02-06"),
            FlightArrivingDate = Convert.ToDateTime("2019-02-06"),
            LocationFrom = "Lviv",
            LocationTo = "London"
        };


        private List<Flight> GetTestFlights()
        {
            var flights = new List<Flight>
            {
                new Flight
                {
                    Id = 1,
                    FlightDepartmentDate = Convert.ToDateTime("2019-02-06"),
                    FlightArrivingDate = Convert.ToDateTime("2019-02-06"),
                    LocationFrom = "Lviv",
                    LocationTo = "London"
                },

                new Flight
                {
                    Id = 2,
                    FlightDepartmentDate = Convert.ToDateTime("2019-03-06"),
                    FlightArrivingDate = Convert.ToDateTime("2019-03-06"),
                    LocationFrom = "Lviv",
                    LocationTo = "London"
                }
            };
            return flights;
        }

        private List<TicketViewModel> GetTestTicket()
        {
            var ticketViews = new List<TicketViewModel>
            {
                new TicketViewModel { Id = 1, FlightDepartmentDate = Convert.ToDateTime("2019-02-06"), FlightArrivingDate = Convert.ToDateTime("2019-02-06"), Price = 900, LocationFrom = "Lviv" , LocationTo = "London"},
                new TicketViewModel { Id = 2, FlightDepartmentDate = Convert.ToDateTime("2019-02-06"), FlightArrivingDate = Convert.ToDateTime("2019-02-06"), Price = 300, LocationFrom = "Lviv" , LocationTo = "London"},
                new TicketViewModel { Id = 3, FlightDepartmentDate = Convert.ToDateTime("2019-02-06"), FlightArrivingDate = Convert.ToDateTime("2019-02-06"), Price = 400, LocationFrom = "NY" , LocationTo = "Lviv"},
                new TicketViewModel { Id = 4, FlightDepartmentDate = Convert.ToDateTime("2019-02-06"), FlightArrivingDate = Convert.ToDateTime("2019-02-06"), Price = 900, LocationFrom = "NY" , LocationTo = "Lviv"},
            };
            return ticketViews;
        }

        private List<User> GetTestUser()
        {
            var users = new List<User>
            {
                new User { Id = '1'.ToString(), Email = "oleg@google.com" },
                new User { Id = '2'.ToString(), Email = "oleh@google.com" },
                new User { Id = '3'.ToString(), Email = "oleh@user.com" },
                new User { Id = '4'.ToString(), Email = "oleg@user.com" },
            };
            return users;
        }
    }
}

