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
using Xunit;

namespace TicketsBooking.Test.BLL
{
    public class UserServiceTest
    {
        private UserService service;
        private IEnumerable<User> users;

        [Fact]
        public void GetAllUsersTest()
        {
            users = service.GetAll();
           
        }

    }
}
