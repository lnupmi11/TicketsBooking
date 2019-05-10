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
        private DbSet<TEntity> _dbSet;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
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
            return _dbSet.Where(condition);
        }

        public TEntity Get(string id)
        {
            return _dbSet.Find(Int32.Parse(id));
        }

        public TEntity Get(Func<TEntity, bool> condition)
        {
            return _dbSet.FirstOrDefault(condition);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public IQueryable<TEntity> GetQuery()
        {
            return _dbSet;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
