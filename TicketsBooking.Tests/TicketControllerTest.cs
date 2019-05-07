using System;
using Xunit;
using TicketsBooking.Controllers;
using TicketsBooking.Models;
using TicketsBooking.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TicketsBooking.Tests
{
    public class TicketControllerTest
    {
        [Fact]
        public void HomeViewData()
        {
            //Arrange
            TicketController controller = new TicketController();

            //Act
            var res = controller.Home();

            //Assert
            Assert.IsType<ViewResult>(res);

        }

        [Fact]
        public void DeleteTicketTest()
        {
            //Arrange
            TicketController controller = new TicketController();
            Ticket ticket = new Ticket()
            {
                Id = 1,
                From = new City() { CityName = "Lviv" },
                To = new City() { CityName = "Kyiv" },
                Price = 250
            };
            Context db = new Context();

            //Act
            controller.DeleteTicket(ticket);
            var res = db.Tickets.Any(tic => tic.Id == ticket.Id) ? true : false;

            //Assert
            Assert.False(res);
        }

        [Fact]
        public void GetTicketsByFromToTest()
        {
            //Arrange
            Context db = new Context();
            TicketController controller = new TicketController();

            City cityFrom = db.Cities.First();
            City cityTo = db.Cities.Last();
            var result = true;

            //Act
            var list = controller.GetTicketsByFromTo(cityFrom, cityTo);
            foreach(Ticket ticket in list)
            {
                if((ticket.From.Id != cityFrom.Id)||(ticket.To.Id != cityTo.Id))
                {
                    result = false;
                    break;
                }
            }

            //Assert
            Assert.True(result);
        }
    }
}
