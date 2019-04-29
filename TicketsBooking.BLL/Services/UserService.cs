using System;
using System.Collections.Generic;
using System.Text;
using TicketsBooking.BLL.Interfaces;
using TicketsBooking.DAL.Entities;
using TicketsBooking.DAL.Repositories;
using TicketsBooking.DAL.EntityFramework;

namespace TicketsBooking.BLL.Services
{
    public class UserService : IServiceUser
    {
        public void ChangeFirstname(User user, string firstname)
        {
            using (TicketsBookingContext db = new TicketsBookingContext())
            {
                user.FirstName = firstname;
                db.Update(user);
            }
        }

        public void ChangeLastname(User user, string lastname)
        {
            using (TicketsBookingContext db = new TicketsBookingContext())
            {
                user.LastName = lastname;
                db.Update(user);
            }
        }

        public void ChangeUsername(User user, string name)
        {
            using (TicketsBookingContext db = new TicketsBookingContext())
            {
                user.UserName = name;
                db.Update(user);
            }
        }

        public void Delete(User user)
        {
            UserRepository userRepository = new UserRepository();
            userRepository.Delete(user.Id.ToString());
        }

        public IEnumerable<User> GetAll()
        {
            UserRepository userRepository = new UserRepository();
            return userRepository.GetAll();
        }

        public User GetUser(string id)
        {
            UserRepository userRepository = new UserRepository();
            return userRepository.Get(id);
        }
    }
}
