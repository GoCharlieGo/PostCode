using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PostCode.Repository
{
    public interface IRepository<T>:IDisposable where T : IEntity
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        T Delete(T entity);
        void Edit(T entity);
        void Save();
    }
}
