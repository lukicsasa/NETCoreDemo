using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Demo.Data
{
    public abstract class GenericRepository<T> where T : class
    {
        protected DbContext _context;

        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public bool Any(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().Any(match);
        }

        public virtual T GetById(long id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual T FirstOrDefault(Expression<Func<T, bool>> match, string includeProperties = null)
        {
            var query = Include(includeProperties);
            return query.FirstOrDefault(match);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> match, string includeProperties = null)
        {
            var query = Include(includeProperties);
            return query.Where(match);
        }

        public virtual T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual T Update(T entity, object key)
        {
            if (entity == null) return null;
            T exists = _context.Set<T>().Find(key);
            if (exists != null)
            {
                _context.Entry(exists).CurrentValues.SetValues(entity);
            }
            return entity;
        }

        public long Count()
        {
            return _context.Set<T>().Count();
        }

        public long Count(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().Count(match);
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private IQueryable<T> Include(string includeProperties, IQueryable<T> query = null)
        {
            if (query == null)
                query = _context.Set<T>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(includeProperties))
            {
                foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }

            return query;
        }
    }
}
