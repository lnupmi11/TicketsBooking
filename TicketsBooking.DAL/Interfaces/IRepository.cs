﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicketsBooking.DAL.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllWhere(Func<T, bool> predicate);
        T Get(string id);
        T Get(Func<T, bool> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(string id);
        void SaveChanges();
        IQueryable<T> GetQuery();
    }
}
