using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;
using TicketsBooking.BLL.Services;
using TicketsBooking.DAL;
using TicketsBooking.DAL.Interfaces;
using TicketsBooking.DAL.Entities;
using TicketsBooking.DTO.User;
using TicketsBooking.DAL.EntityFramework;
using TicketsBooking.DAL.UnitOfWork;
using TicketsBooking.BLL.Interfaces;
using Xunit;
using AutoMapper;

namespace TicketsBooking.Tests
{
    public class UserServiceTest
    {
        private readonly IServiceUser userService;
        private TicketsBookingUnitOfWork unitOfWork;
        private Mock<IRepository<User>> userMockRepository;
        private Mock<IMapper> mapper;

        public UserServiceTest()
        {
            mapper = new Mock<IMapper>();
            unitOfWork = new TicketsBookingUnitOfWork(null);
            userMockRepository = new Mock<IRepository<User>>();
            unitOfWork.UserRepository = userMockRepository.Object;
            userService = new UserService(unitOfWork, mapper.Object);

            Initialize();
        }


        [Fact]
        public void GetAllTest()
        {
            //Arrange
            var testCollection = GetUserCollection();

            //Act
            userMockRepository.Setup(x => x.GetAll()).Returns(GetUserCollection());
            var actualCollection = userService.GetAll();

            //Assert
            Assert.Equal(testCollection.Count(), actualCollection.Count());
            Assert.Equal(testCollection.ElementAt(0).FirstName, actualCollection.ElementAt(0).FirstName);
            Assert.Equal(testCollection.ElementAt(0).LastName, actualCollection.ElementAt(0).LastName);
            Assert.Equal(testCollection.ElementAt(0).UserName, actualCollection.ElementAt(0).UserName);

        }

        [Fact]
        public void GetUserTest()
        {
            //Arrange
            int index = 0;
            var testUser = GetUserCollection().ElementAt(index);

            //Act
            userMockRepository.Setup(x => x.Get(index.ToString())).Returns(GetUserCollection().ElementAt(index));
            mapper.Setup(x => x.Map<User>(It.IsAny<User>())).Returns(GetUserCollection().ElementAt(index));
            var actualUser = userService.GetUser(index.ToString());

            //Assert
            Assert.Equal(testUser.UserName, actualUser.UserName);
            Assert.Equal(testUser.FirstName, actualUser.FirstName);
            Assert.Equal(testUser.LastName, actualUser.LastName);
        }

        [Fact]
        public void ChangeUsernameTest()
        {
            //Arrange
            int index = 0;
            var testUser = GetUserCollection().ElementAt(index);

            //Act
            userMockRepository.Setup(x => x.Get(index.ToString())).Returns(GetUserCollection().ElementAt(index));
            mapper.Setup(x => x.Map<User>(It.IsAny<User>())).Returns(GetUserCollection().ElementAt(index));
            userService.ChangeUsername(testUser, "newname");

            //Assert
            Assert.Equal(testUser.UserName, "newname");
        }

        [Fact]
        public void ChangeFirstnameTest()
        {
            //Arrange
            int index = 0;
            var testUser = GetUserCollection().ElementAt(index);

            //Act
            userMockRepository.Setup(x => x.Get(index.ToString())).Returns(GetUserCollection().ElementAt(index));
            mapper.Setup(x => x.Map<User>(It.IsAny<User>())).Returns(GetUserCollection().ElementAt(index));
            userService.ChangeFirstname(testUser, "NewFirstname");

            //Assert
            Assert.Equal(testUser.FirstName, "NewFirstname");
        }

        [Fact]
        public void ChangeLastnameTest()
        {
            //Arrange
            int index = 0;
            var testUser = GetUserCollection().ElementAt(index);

            //Act
            userMockRepository.Setup(x => x.Get(index.ToString())).Returns(GetUserCollection().ElementAt(index));
            mapper.Setup(x => x.Map<User>(It.IsAny<User>())).Returns(GetUserCollection().ElementAt(index));
            userService.ChangeLastname(testUser, "NewLastname");

            //Assert
            Assert.Equal(testUser.LastName, "NewLastname");
        }



        //Test data

        private void Initialize()
        {
            mapper.Setup(x => x.Map<User>(GetUserCollection().ToList()[0])).Returns(GetUserCollection().ToList()[0]);
            mapper.Setup(x => x.Map<User>(GetUserCollection().ToList()[1])).Returns(GetUserCollection().ToList()[1]);
            mapper.Setup(x => x.Map<User>(GetUserCollection().ToList()[2])).Returns(GetUserCollection().ToList()[2]);
            mapper.Setup(x => x.Map<User>(GetUserCollection().ToList()[3])).Returns(GetUserCollection().ToList()[3]);
            mapper.Setup(x => x.Map<User>(GetUserCollection().ToList()[4])).Returns(GetUserCollection().ToList()[4]);
            mapper.Setup(x => x.Map<User>(GetUserCollection().ToList()[5])).Returns(GetUserCollection().ToList()[5]);
        }

        private IEnumerable<User> GetUserCollection()
        {
            return new[]
            {
                new User{UserName = "username1",  FirstName = "firstname1", LastName = "lastname1"},
                new User{UserName = "username2",  FirstName = "firstname2", LastName = "lastname2"},
                new User{UserName = "username3",  FirstName = "firstname3", LastName = "lastname3"},
                new User{UserName = "username4",  FirstName = "firstname4", LastName = "lastname4"},
                new User{UserName = "username5",  FirstName = "firstname5", LastName = "lastname5"},
                new User{UserName = "username6",  FirstName = "firstname6", LastName = "lastname6"}
            };
        }


    }
}