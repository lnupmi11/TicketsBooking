using System;
using System.Collections.Generic;
using System.Text;
using TicketsBooking.DTO.Ticket;

namespace TicketsBooking.BLL.Interfaces
{
    public interface IServiceBoughtTicket
    {
        void Create(BoughtTicketDTO ticket);
        BoughtTicketDTO Get(int id);
        void Delete(int id);
        void Update(BoughtTicketDTO ticket);
        IEnumerable<BoughtTicketDTO> GetAll();
    }
}
