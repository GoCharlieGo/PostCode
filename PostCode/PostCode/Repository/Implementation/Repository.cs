﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using PostCode.Models;

namespace PostCode.Repository
{
    public abstract class Repository<T> : IRepository<T > where T : class, IEntity 
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

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> query = _entities.Set<T>().Where(predicate).AsEnumerable();
            return query;
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
            var dbEntity = _entities.Set<T>().FirstOrDefault(e => e.Id == entity.Id);
            if (dbEntity != null) _entities.Entry((object) dbEntity).CurrentValues.SetValues(entity);
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