using System;
using System.Collections.Generic;
using System.Text;
using TicketsBooking.DAL.Entities;
using TicketsBooking.DTO.Ticket;

namespace TicketsBooking.BLL.Interfaces
{
    public interface IServiceTicket
    {
        void Create(TicketDTO ticket);
        void Delete(int id);
        void Update(TicketDTO ticket);
        IEnumerable<TicketDTO> GetAll();
        TicketDTO Get(int id);
    }
}
