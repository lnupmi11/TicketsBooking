using System;
using System.Collections.Generic;
using System.Text;
using TicketsBooking.DAL.Entities;

namespace TicketsBooking.BLL.Interfaces
{
    interface IServiceTicket
    {
        void Create(Ticket ticket);
        void Delete(int id);
        void Update(Ticket ticket);
        IEnumerable<Ticket> GetAll();
        Ticket Get(int id);
    }
}
