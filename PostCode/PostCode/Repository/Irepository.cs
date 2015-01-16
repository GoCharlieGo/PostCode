using System;
using System.Collections.Generic;

namespace PostCode.Repository
{
    public interface IRepository<T>:IDisposable where T : IEntity
    {
        IEnumerable<T> GetAll();
        T Add(T entity);
        T Delete(T entity);
        void Edit(T entity);
        void Save();
    }
}
