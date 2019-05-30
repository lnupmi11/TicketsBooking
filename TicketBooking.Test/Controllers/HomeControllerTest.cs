using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using TicketsBooking.Controllers;
using TicketsBooking.BLL.Services;
using Moq;
using Xunit;
using TicketsBooking.DAL.UnitOfWork;
using TicketsBooking.BLL.Interfaces;

namespace TicketsBooking.Test.Controllers
{
    class HomeControllerTest
    {
        private readonly HomeController homeController;
        private readonly TicketsBookingUnitOfWork unitOfWork;
        private readonly Mock<IServiceTicket> ticketServiceMock;
        private readonly Mock<IServiceFlight> flightServiceMock;
        private readonly Mock<IOrderService> orderServiceMock;
        private readonly Mock<IServiceUser> userServiceMock;
    }
}
