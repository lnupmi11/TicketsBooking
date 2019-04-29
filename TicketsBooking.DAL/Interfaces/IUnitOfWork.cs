using TicketsBooking.DAL.Entities;

namespace TicketsBooking.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<City> CityRepository { get; }
        IRepository<Ticket> TicketRepository { get; }
        IRepository<User> UserRepository { get; }
        void SaveChanges();
    }
}
