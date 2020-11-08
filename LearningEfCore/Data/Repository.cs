using LearningEfCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LearningEfCore.Data
{
    class Repository<T>
        where T : class, Identifiable
    {
        private readonly EfContext db;
        private readonly DbSet<T> dbSet;

        public Repository(EfContext db)
        {
            this.db = db;
            dbSet = this.db.Set<T>();
        }

        internal void Create(T entity)
        {
            dbSet.Add(entity);
        }

        internal void Create(List<T> entities)
        {
            entities.ForEach(ent =>
            {
                Create(ent);
            });
        }

        internal T Read(int entityId)
        {
            return dbSet.Find(entityId);
        }

        internal T FirstOrDefault(Func<T, bool> predicate)
        {
            return dbSet.FirstOrDefault(predicate);
        }

        internal List<T> Where(Func<T, bool> predicate)
        {
            return dbSet.Where(predicate).ToList();
        }

        internal List<OUT> Select<OUT>(Func<T, OUT> select)
        {
            return dbSet.Select(select).ToList();
        }

        internal void Update(T entity)
        {
            if (entity.Id <= 0)
                throw new Exception("Id cannot be missing.");

            dbSet.Update(entity);
        }

        internal void Update(List<T> entities)
        {
            entities.ForEach(ent =>
            {
                Update(ent);
            });
        }

        internal void Delete(int entityId)
        {
            if (entityId <= 0)
                throw new Exception("Id cannot be missing.");

            T entity = Read(entityId);

            if (entity == null)
                throw new Exception("Entity not found.");

            dbSet.Remove(entity);
        }

        internal void Delete(List<int> entityIds)
        {
            entityIds.ForEach(entId =>
            {
                Delete(entId);
            });
        }

        internal void Commit()
        {
            using (var trans = db.Database.BeginTransaction())
            {
                try
                {
                    db.SaveChanges();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
        }
    }
}
