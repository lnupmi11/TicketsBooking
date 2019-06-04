using System;
using System.Collections.Generic;
using System.Text;
using TicketsBooking.DAL.Entities;

namespace TicketsBooking.BLL.Interfaces
{
    public interface IServiceLike
    {
        void Create(Like ticket);
        void Delete(int id);
        void Update(Like ticket);
        IEnumerable<Like> GetAll();
        Like Get(int id);
    }
}
