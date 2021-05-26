using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserService.Repository.CommandDB;
using UserService.Repository.Interfaces;

namespace UserService.Repository.Repositories
{
    public class BaseRepository<T> : BaseIRepository<T> where T : class
    {
        private readonly Context _context;
        private DbSet<T> entities;

        public BaseRepository(Context context)
        {
            _context = context;
            entities = context.Set<T>();
        }

        public void Insert(T entity)
        {
            if (entity == null)
                throw new NullReferenceException();

            _context.Add(entity);
        }

        public void InsertMany(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new NullReferenceException();

            if (!entities.Any())
                return;

            _context.AddRange(entities);
        }

        public void Update(T entity)
        {
            if (entity == null)
                throw new NullReferenceException();

            _context.Update(entity);
        }

        public void UpdateMany(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new NullReferenceException();

            if (!entities.Any())
                return;

            _context.UpdateRange(entities);
        }

        public void Delete(T entity)
        {
            if (entity == null)
                throw new NullReferenceException();

            _context.Remove(entity);
        }

        public void DeleteMany(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new NullReferenceException();

            if (!entities.Any())
                return;

            _context.RemoveRange(entities);
        }

        public IQueryable<T> Get()
        {
            return entities;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
