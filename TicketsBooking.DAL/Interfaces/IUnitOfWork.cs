using TicketsBooking.DAL.Entities;

namespace TicketsBooking.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Ticket> TicketRepository { get; }
        IRepository<User> UserRepository { get; set; }
        IRepository<Flight> FlightRepository { get; }
        IRepository<Basket> BasketRepository { get; }
        IRepository<TicketType> TicketTypeRepository { get; }
        IRepository<BoughtTicket> BoughtTicketRepository { get; }
        IRepository<Like> LikeRepository { get; set; }
        void SaveChanges();
    }
}
