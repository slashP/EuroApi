using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EuroApi.DAL
{
    public interface IRepository<T>
    {
        T Find(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Query(Expression<Func<T, bool>> filter);
        T Add(T entity);
        void Remove(T entity);
        void Save();
    }
}