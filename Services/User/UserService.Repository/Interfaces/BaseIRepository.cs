using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserService.Repository.Interfaces
{
    public interface BaseIRepository<T>// : IDisposable where T: class //(pq eu deveria colocar o where?)
    {
        void Insert(T entity);
        void InsertMany(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateMany(IEnumerable<T> entities);
        void Delete(T entity);
        void DeleteMany(IEnumerable<T> entities);
        IQueryable<T> Get();
        void Commit();
    }
}
