using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicketsBooking.DAL.Interfaces
{
    public interface IRepository<T>
    {
<<<<<<< HEAD
=======
        // Create/Update/Delete:
        void Create(T item);
        void Update(T item);
        void Delete(T item);
        void Delete(string id);


        // Get:
>>>>>>> 0e127cf524409f8905fc900e2d2b147be317dad8
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
