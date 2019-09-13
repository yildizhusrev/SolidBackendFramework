using TmTFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TmTFramework.Core.DataAccess
{
    public interface IEntityRepository<T> where T:class , IEntity, new()
    {
        List<T> GetList(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter = null);
        T Add(T entity);
        List<T> AddRange(List<T> items);
        T Update(T entity);
        void Delete(T entity);
        void DeleteRange(List<T> entities);
    }
}
