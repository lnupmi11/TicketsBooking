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
    public class LikeServiceTest
    {
        private readonly IServiceLike likeService;
        private TicketsBookingUnitOfWork unitOfWork;
        private Mock<IRepository<Like>> likeMockRepository;
        private Mock<IMapper> mapper;

        public LikeServiceTest()
        {
            mapper = new Mock<IMapper>();
            unitOfWork = new TicketsBookingUnitOfWork(null);
            likeMockRepository = new Mock<IRepository<Like>>();
            unitOfWork.LikeRepository = likeMockRepository.Object;
            likeService = new LikeServices(unitOfWork, mapper.Object);

            Initialize();
        }

        [Fact]
        public void CreateTest()
        {
            //Arrange
            var like = new Like() { UserEmail = "oleg@user.com", FlightId = 1 };
            var likeDTO = new Like() { UserEmail = "oleg@user.com", FlightId = 1 };

            List<Like> likes = new List<Like>();

            likeMockRepository.Setup(x => x.GetAll()).Returns(likes);
            likeMockRepository.Setup(x => x.Create(like)).Callback((Like t) => { likes.Add(new Like()); });
            mapper.Setup(x => x.Map<Like>(likeDTO)).Returns(like);

            likeService.Create(like);

            Assert.Single(likeService.GetAll());
        }

        [Fact]
        public void DeleteTest()
        {
            //Arrange
            List<Like> likes = new List<Like>();
            var like1 = new Like() { Id = 1, UserEmail = "oleg@user.com", FlightId = 1 };
            var like2 = new Like() { Id = 2, UserEmail = "oleg@user.com", FlightId = 2 };

            likes.Add(like1);
            likes.Add(like2);

            //Act
            likeMockRepository.Setup(x => x.GetAll()).Returns(likes);
            likeMockRepository.Setup(x => x.Delete(like1.Id.ToString()));
            mapper.Setup(x => x.Map<Like>(like1)).Returns(like1);

            likeService.Delete(like1.Id);


            //Assert
            Assert.Null(likeService.Get(like1.Id));
        }

        [Fact]
        public void GetAllTest()
        {
            //Arrange
            var testCollection = LikeCollection();

            //Act
            var actualCollection = likeService.GetAll();

            //Assert
            Assert.Equal(testCollection.Count(), actualCollection.Count());

        }

        //[Fact]
        //public void GetTicketTest()
        //{
        //    //Arrange
        //    int index = 1;
        //    var testTicket = GetTicketCollection().ElementAt(index);

        //    //Act            
        //    ticketMockRepository.Setup(x => x.Get(index.ToString())).Returns(GetTicketCollection().ElementAt(index));
        //    mapper.Setup(x => x.Map<TicketDTO>(It.IsAny<Ticket>())).Returns(GetTicketCollectionDTO().ElementAt(index));
        //    var actualTicket = ticketService.Get(index);

        //    //Assert
        //    Assert.Equal(testTicket.Id, actualTicket.Id);
        //    Assert.Equal(testTicket.Price, actualTicket.Price);
        //    Assert.Equal(testTicket.Type.Id, actualTicket.Type.Id);
        //}

        //Test data

        private void Initialize()
        {
            mapper.Setup(x => x.Map<Like>(LikeCollection().ToList()[0])).Returns(GetLikeCollectionDTO().ToList()[0]);
            mapper.Setup(x => x.Map<Like>(LikeCollection().ToList()[1])).Returns(GetLikeCollectionDTO().ToList()[1]);
            mapper.Setup(x => x.Map<Like>(LikeCollection().ToList()[2])).Returns(GetLikeCollectionDTO().ToList()[2]);
            mapper.Setup(x => x.Map<Like>(LikeCollection().ToList()[3])).Returns(GetLikeCollectionDTO().ToList()[3]);
            mapper.Setup(x => x.Map<Like>(LikeCollection().ToList()[4])).Returns(GetLikeCollectionDTO().ToList()[4]);
            mapper.Setup(x => x.Map<Like>(LikeCollection().ToList()[5])).Returns(GetLikeCollectionDTO().ToList()[5]);


            likeMockRepository.Setup(x => x.GetAll()).Returns(LikeCollection());
        }

        private IEnumerable<Like> LikeCollection()
        {
            return new[]
            {
                new Like { Id = 1,  UserEmail = "oleg@user.com", FlightId = 1 },
                new Like { Id = 2,  UserEmail = "oleg@user.com", FlightId = 2 },
                new Like { Id = 3,  UserEmail = "oleg@user.com", FlightId = 3 },
                new Like { Id = 4,  UserEmail = "oleg@user.com", FlightId = 4 },
                new Like { Id = 5,  UserEmail = "oleg@user.com", FlightId = 5 },
                new Like { Id = 6,  UserEmail = "oleg@user.com", FlightId = 6 }
            };
        }

        private IEnumerable<Like> GetLikeCollectionDTO()
        {
            return new[]
            {
                new Like { Id = 1,  UserEmail = "oleg@user.com", FlightId = 1 },
                new Like { Id = 2,  UserEmail = "oleg@user.com", FlightId = 2 },
                new Like { Id = 3,  UserEmail = "oleg@user.com", FlightId = 3 },
                new Like { Id = 4,  UserEmail = "oleg@user.com", FlightId = 4 },
                new Like { Id = 5,  UserEmail = "oleg@user.com", FlightId = 5 },
                new Like { Id = 6,  UserEmail = "oleg@user.com", FlightId = 6 }
            };
        }

    }
}