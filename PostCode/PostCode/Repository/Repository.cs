using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace PostCode.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected DbContext _entities;

        protected Repository(DbContext сontext)
        {
            _entities = сontext;
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.Set<T>().AsEnumerable();
        }
        public T Add(T entity)
        {
            return _entities.Set<T>().Add(entity);
        }

        public T Delete(T entity)
        {
            return _entities.Set<T>().Remove(entity);
        }

        public void Edit(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            _entities.SaveChanges();
        }

        public void Dispose()
        {
            _entities.Dispose();
        }
    }
}