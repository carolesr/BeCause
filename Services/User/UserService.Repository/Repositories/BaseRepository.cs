using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using UserService.Domain.Entities;
using UserService.Repository.CommandDB;
using UserService.Repository.Interfaces;

namespace UserService.Repository.Repositories
{
    public class BaseRepository<T> : BaseIRepository<T> where T : BaseEntity
    {
        private readonly Context _context;
        private DbSet<T> entities;

        public BaseRepository(Context context)
        {
            _context = context;
            entities = context.Set<T>();
        }

        public void Insert(T entity, bool commit = true)
        {
            if (entity == null)
                throw new NullReferenceException();

            entity.CreatedAt = DateTime.Now;
            entity.IdResponsible = 1; // TODO: implementar GetUserLogado

            _context.Add(entity);

            if (commit) Commit();
        }

        public void InsertMany(IEnumerable<T> entities, bool commit = true)
        {
            if (entities == null)
                throw new NullReferenceException();

            if (!entities.Any())
                return;

            foreach (var e in entities)
            {
                e.CreatedAt = DateTime.Now;
                e.IdResponsible = 1;
            }

            _context.AddRange(entities);

            if (commit) Commit();
        }

        public void Update(T entity, bool commit = true)
        {
            if (entity == null)
                throw new NullReferenceException();

            entity.UpdatedAt = DateTime.Now;
            entity.IdResponsible = 1;

            _context.Update(entity);

            if (commit) Commit();
        }

        public void UpdateMany(IEnumerable<T> entities, bool commit = true)
        {
            if (entities == null)
                throw new NullReferenceException();

            if (!entities.Any())
                return;

            foreach (var e in entities)
            {
                e.UpdatedAt = DateTime.Now;
                e.IdResponsible = 1;
            }

            _context.UpdateRange(entities);

            if (commit) Commit();
        }

        public void Delete(T entity, bool commit = true)
        {
            if (entity == null)
                throw new NullReferenceException();

            _context.Remove(entity);

            if (commit) Commit();
        }

        public void DeleteMany(IEnumerable<T> entities, bool commit = true)
        {
            if (entities == null)
                throw new NullReferenceException();

            if (!entities.Any())
                return;

            _context.RemoveRange(entities);

            if (commit) Commit();
        }

        public IQueryable<T> Get()
        {
            return entities;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
