using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;
using TicketsBooking.BLL.Services;
using TicketsBooking.DAL;
using TicketsBooking.DAL.Interfaces;
using TicketsBooking.DAL.Entities;
using TicketsBooking.DTO.Flight;
using TicketsBooking.DAL.EntityFramework;
using TicketsBooking.DAL.UnitOfWork;
using TicketsBooking.BLL.Interfaces;
using Xunit;
using AutoMapper;

namespace TicketsBooking.Tests
{
    public class FlightServiceTest
    {
        private readonly IServiceFlight flightService;
        private TicketsBookingUnitOfWork unitOfWork;
        private Mock<IRepository<Flight>> flightMockRepository;
        private Mock<IMapper> mapper;

        public FlightServiceTest()
        {
            mapper = new Mock<IMapper>();
            unitOfWork = new TicketsBookingUnitOfWork(null);
            flightMockRepository = new Mock<IRepository<Flight>>();
            unitOfWork.FlightRepository = flightMockRepository.Object;
            flightService = new FlightService(unitOfWork, mapper.Object);

            Initialize();
        }
        [Fact]
        public void CreateTest()
        {
            //Arrange
            var flight = new Flight() { LocationFrom = "Lviv", LocationTo = "Kyiv" };
            var flightDTO = new FlightDTO() { LocationFrom = "Lviv", LocationTo = "Kyiv" };

            List<Flight> flights = new List<Flight>();

            flightMockRepository.Setup(x => x.GetAll()).Returns(flights);
            flightMockRepository.Setup(x => x.Create(flight)).Callback((Flight f) => { flights.Add(new Flight()); });
            mapper.Setup(x => x.Map<Flight>(flightDTO)).Returns(flight);

            flightService.Create(flightDTO);

            Assert.Single(flightService.GetAll());
        }

        [Fact]
        public void DeleteTest()
        {
            //Arrange
            List<Flight> flights = new List<Flight>();
            var flight1 = new Flight() { LocationFrom = "Lviv", LocationTo = "Kyiv" };
            var flight2 = new Flight() { LocationFrom = "Lviv", LocationTo = "Odesa" };
            flights.Add(flight1);
            flights.Add(flight2);

            //Act
            flightMockRepository.Setup(x => x.GetAll()).Returns(flights);
            flightMockRepository.Setup(x => x.Delete(flight1.Id.ToString()));
            mapper.Setup(x => x.Map<Flight>(flight1)).Returns(flight1);

            flightService.Delete(flight1.Id);


            //Assert
            Assert.Null(flightService.Get(flight1.Id));
        }

        [Fact]
        public void GetAllTest()
        {
            //Arrange
            var testCollection = GetFlightCollection();

            //Act
            var actualCollection = flightService.GetAll();

            //Assert
            Assert.Equal(testCollection.Count(), actualCollection.Count());

        }

        [Fact]
        public void GetFlightTest()
        {
            //Arrange
            int index = 1;
            var testFlight = GetFlightCollection().ElementAt(index);

            //Act            
            flightMockRepository.Setup(x => x.Get(index.ToString())).Returns(GetFlightCollection().ElementAt(index));
            mapper.Setup(x => x.Map<FlightDTO>(It.IsAny<Flight>())).Returns(GetFlightCollectionDTO().ElementAt(index));
            var actualFlight = flightService.Get(index);

            //Assert
            Assert.Equal(testFlight.LocationFrom, actualFlight.LocationFrom);
            Assert.Equal(testFlight.LocationTo, actualFlight.LocationTo);
        }

        [Fact]
        public void UpdateFlightTest()
        {

            //Arrange
            int index = 1;
            var testFlight = GetFlightCollection().ElementAt(index);

            //Act            
            flightMockRepository.Setup(x => x.Get(index.ToString())).Returns(GetFlightCollection().ElementAt(index));
            mapper.Setup(x => x.Map<FlightDTO>(It.IsAny<Flight>())).Returns(GetFlightCollectionDTO().ElementAt(index));
            var actualFlight = flightService.Get(index);
        }

        //Test data

        private void Initialize()
        {
            mapper.Setup(x => x.Map<FlightDTO>(GetFlightCollection().ToList()[0])).Returns(GetFlightCollectionDTO().ToList()[0]);
            mapper.Setup(x => x.Map<FlightDTO>(GetFlightCollection().ToList()[1])).Returns(GetFlightCollectionDTO().ToList()[1]);
            mapper.Setup(x => x.Map<FlightDTO>(GetFlightCollection().ToList()[2])).Returns(GetFlightCollectionDTO().ToList()[2]);
            mapper.Setup(x => x.Map<FlightDTO>(GetFlightCollection().ToList()[3])).Returns(GetFlightCollectionDTO().ToList()[3]);
            mapper.Setup(x => x.Map<FlightDTO>(GetFlightCollection().ToList()[4])).Returns(GetFlightCollectionDTO().ToList()[4]);
            mapper.Setup(x => x.Map<FlightDTO>(GetFlightCollection().ToList()[5])).Returns(GetFlightCollectionDTO().ToList()[5]);


            flightMockRepository.Setup(x => x.GetAll()).Returns(GetFlightCollection());
        }
        private IEnumerable<Flight> GetFlightCollection()
        {
            return new[]
            {
                new Flight { Id = 1,  LocationFrom = "Lviv", LocationTo = "Odesa" },
                new Flight { Id = 2, LocationFrom = "Lviv", LocationTo = "Kyiv"  },
                new Flight { Id = 3, LocationFrom = "Kyiv", LocationTo = "Odesa"  },
                new Flight { Id = 4,LocationFrom = "Lviv", LocationTo = "Lutsk"  },
                new Flight { Id = 5, LocationFrom = "Ivano-Frankivsk", LocationTo = "Odesa"  },
                new Flight { Id = 6, LocationFrom = "Lviv", LocationTo = "Ternopyl"  }
            };
        }

        private IEnumerable<FlightDTO> GetFlightCollectionDTO()
        {
            return new[]
            {
                new FlightDTO { Id = 1,  LocationFrom = "Lviv", LocationTo = "Odesa" },
                new FlightDTO { Id = 2, LocationFrom = "Lviv", LocationTo = "Kyiv"  },
                new FlightDTO { Id = 3, LocationFrom = "Kyiv", LocationTo = "Odesa"  },
                new FlightDTO { Id = 4,LocationFrom = "Lviv", LocationTo = "Lutsk"  },
                new FlightDTO { Id = 5, LocationFrom = "Ivano-Frankivsk", LocationTo = "Odesa"  },
                new FlightDTO { Id = 6, LocationFrom = "Lviv", LocationTo = "Ternopyl"  }
            };
        }
    }

}