using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TicketsBooking.DAL.Interfaces;

namespace TicketsBooking.DAL.Repositories
{
    class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbContext _context;

        public GenericRepository(DbContext context)
        {
            _context = context;
           
        }

        public void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var entity = _context.Set<TEntity>().Find(Int32.Parse(id));
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
            }
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<TEntity> GetAllWhere(Func<TEntity, bool> condition)
        {
            return _context.Set<TEntity>().Where(condition);
        }

        public TEntity Get(string id)
        {
            return _context.Set<TEntity>().Find(Int32.Parse(id));
        }

        public TEntity Get(Func<TEntity, bool> condition)
        {
            return _context.Set<TEntity>().FirstOrDefault(condition);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public IQueryable<TEntity> GetQuery()
        {
            return _context.Set<TEntity>();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
