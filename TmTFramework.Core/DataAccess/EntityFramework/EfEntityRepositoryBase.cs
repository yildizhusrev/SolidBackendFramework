using TmTFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace TmTFramework.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity> 
        where TEntity:class,IEntity,new ()
       where TContext:DbContext,new ()
    {
        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context= new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public TEntity Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity); // context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
                return entity;
            }
        }

        // IEnumerable<TEntity> AddRange(IEnumerable<TEntity> items);
        public List<TEntity> AddRange(List<TEntity> entities)
        {
            using (var context = new TContext())
            {
                
                var addedEntries = context.Set<TEntity>().AddRange(entities);
                context.SaveChanges();
                return entities;
            }
        }

        

        public TEntity Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
                return entity;

            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
                
            }
            
        }

        public void DeleteRange(List<TEntity> entities)
        {

            foreach (var entity in entities)
            {
                Delete(entity);
            }
            //using (var context = new TContext())
            //{
            //   context.Set<TEntity>().RemoveRange(entities);
            //   context.SaveChanges();

            //}

        }
    }
}
