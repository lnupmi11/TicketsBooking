using TicketsBooking.DAL.Entities;

namespace TicketsBooking.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<City> CityRepository { get; }
        IRepository<Ticket> TicketRepository { get; }
        IRepository<User> UserRepository { get; }
        IRepository<Flight> FlightRepository { get; }
        IRepository<Basket> BasketRepository { get; }
        IRepository<TicketType> TicketTypeRepository { get; }
        void SaveChanges();
    }
}
