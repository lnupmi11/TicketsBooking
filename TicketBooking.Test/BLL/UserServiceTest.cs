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

namespace TicketsBooking.Test.BLL
{
    public class UserServiceTest
    {
        private  UserService userService;
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

            //Assert
            Assert.Equal(1, 1);
                       
        }



        //Test data

        private void Initialize()
        {
            mapper.Setup(x => x.Map<UserDTO>(GetUserCollection().ToList()[0])).Returns(GetUserCollectionDTO().ToList()[0]);
            mapper.Setup(x => x.Map<UserDTO>(GetUserCollection().ToList()[1])).Returns(GetUserCollectionDTO().ToList()[1]);
            mapper.Setup(x => x.Map<UserDTO>(GetUserCollection().ToList()[2])).Returns(GetUserCollectionDTO().ToList()[2]);
            mapper.Setup(x => x.Map<UserDTO>(GetUserCollection().ToList()[3])).Returns(GetUserCollectionDTO().ToList()[3]);
            mapper.Setup(x => x.Map<UserDTO>(GetUserCollection().ToList()[4])).Returns(GetUserCollectionDTO().ToList()[4]);
            mapper.Setup(x => x.Map<UserDTO>(GetUserCollection().ToList()[5])).Returns(GetUserCollectionDTO().ToList()[5]);


            userMockRepository.Setup(x => x.GetAll()).Returns(GetUserCollection());
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

        private IEnumerable<UserDTO> GetUserCollectionDTO()
        {
            return new[]
            {
                new UserDTO{UserName = "username1",  FirstName = "firstname1", LastName = "lastname1"},
                new UserDTO{UserName = "username2",  FirstName = "firstname2", LastName = "lastname2"},
                new UserDTO{UserName = "username3",  FirstName = "firstname3", LastName = "lastname3"},
                new UserDTO{UserName = "username4",  FirstName = "firstname4", LastName = "lastname4"},
                new UserDTO{UserName = "username5",  FirstName = "firstname5", LastName = "lastname5"},
                new UserDTO{UserName = "username6",  FirstName = "firstname6", LastName = "lastname6"}
            };
        }

    }
}
