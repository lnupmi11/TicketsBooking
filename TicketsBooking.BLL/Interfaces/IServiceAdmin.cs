using System;
using System.Collections.Generic;
using System.Text;
using TicketsBooking.DAL.Entities;

namespace TicketsBooking.BLL.Interfaces
{
    public interface IServiceAdmin
    {
        void BanUser(int id);

        void UnbanUser(int id);
    }
}
