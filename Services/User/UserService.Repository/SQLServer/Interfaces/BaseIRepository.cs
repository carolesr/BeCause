using System.Collections.Generic;
using System.Linq;
using UserService.Domain.Entities;

namespace UserService.Repository.SQLServer.Interfaces
{
    public interface BaseIRepository<T> where T : BaseEntity
    {
        void Insert(T entity, bool commit = true);
        void InsertMany(IEnumerable<T> entities, bool commit = true);
        void Update(T entity, bool commit = true);
        void UpdateMany(IEnumerable<T> entities, bool commit = true);
        void Delete(T entity, bool commit = true);
        void DeleteMany(IEnumerable<T> entities, bool commit = true);
        IQueryable<T> Get();
        void Commit();
    }
}
