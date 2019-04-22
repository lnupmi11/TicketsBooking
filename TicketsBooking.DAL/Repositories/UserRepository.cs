using System;
using System.Collections.Generic;
using System.Text;
using TicketsBooking.DAL.Entities;
using TicketsBooking.DAL.EntityFramework;
using TicketsBooking.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TicketsBooking.DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        TicketsBookingContext dbContext = new TicketsBookingContext();

        public void Create(User item)
        {
            dbContext.Users.Add(item);
            dbContext.SaveChanges();
        }

        public void Delete(User item)
        {
            dbContext.Users.Remove(item);
            dbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            var item = dbContext.Users.Find(id);
            dbContext.Users.Remove(item);
            dbContext.SaveChanges();
        }
        
        public void Update(User item, User newItem)
        {
            //TODO: 
        }

        public User Get(string id)
        {
            return dbContext.Users.Find(id);
        }      

        public IEnumerable<User> GetAll()
        {
            return dbContext.Users;
        }

    }
}
