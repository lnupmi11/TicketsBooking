﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TicketsBooking.DAL.Interfaces
{
    public interface IRepository<T>
    {
        // Create/Update/Delete:
        void Create(T item);
        void Update(T item);
        void Delete(T item);
        void Delete(string id);


        // Get:
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllWhere(Func<T, bool> predicate);
        T Get(string id);
        T Get(Func<T, bool> predicate);


    }
}
