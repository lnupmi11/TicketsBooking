using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using TicketsBooking.Controllers;
using TicketsBooking.BLL.Services;
using  TicketsBooking.BLL.Interfaces;
using Moq;
using Xunit;
using TicketsBooking.DAL.UnitOfWork;

namespace TicketsBooking.Test.Controllers
{
    class TicketControllerTest
    {
        private readonly TicketController ticketController;
        private readonly TicketsBookingUnitOfWork unitOfWork;
        private readonly Mock<IServiceTicket> ticketServiceMock;
        private readonly Mock<IServiceFlight> flightServiceMock;
        private readonly Mock<IOrderService> orderServiceMock;
        private readonly Mock<IServiceUser> userServiceMock;

        public TicketControllerTest()
        {
            ticketServiceMock = new Mock<IServiceTicket>();
            flightServiceMock = new Mock<IServiceFlight>();
            orderServiceMock = new Mock<IOrderService>();
            userServiceMock = new Mock<IServiceUser>();
            unitOfWork = new TicketsBookingUnitOfWork(null);

            ticketController = new TicketController(
                unitOfWork,
                ticketServiceMock.Object,
                orderServiceMock.Object,
                flightServiceMock.Object, 
                userServiceMock.Object);

        }

    }
}
