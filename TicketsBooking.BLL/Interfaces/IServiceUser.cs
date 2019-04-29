using System;
using System.Collections.Generic;
using System.Text;
using TicketsBooking.DAL.Entities;

namespace TicketsBooking.BLL.Interfaces
{
    interface IServiceUser
    {
        User GetUser(string id);
        IEnumerable<User> GetAll();
        void ChangeUsername(User user, string name);
        void ChangeFirstname(User user, string firstname);
        void ChangeLastname(User user, string lastname);
        void Delete(User user);
    }
}
