using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TravelBlogs.DAL.Infrastructure;

namespace TravelBlogs.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IQueryable<T> GetAll(PagingInfo paging);
        T Get(int id);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate, PagingInfo paging);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
