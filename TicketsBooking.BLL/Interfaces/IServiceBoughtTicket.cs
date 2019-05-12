using System;
using System.Collections.Generic;
using System.Text;
using TicketsBooking.DTO.Ticket;

namespace TicketsBooking.BLL.Interfaces
{
    public interface IServiceBoughtTicket
    {
        void Create(BoughtTicketDTO ticket);
        void Delete(int id);
        void Update(BoughtTicketDTO ticket);
        IEnumerable<BoughtTicketDTO> GetAll();
    }
}
