using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TmTFramework.Core.Entities;

namespace TmTFramework.Core.DataAccess.Dapper
{
    public class DapperRepositoryBase<TEntity> : IEntityRepository<TEntity>
        where TEntity:class,IEntity, new()
    {
        private DapperHelper<TEntity> _dapperHelper;
        public DapperRepositoryBase(DapperHelper<TEntity> dapperHelper)
        {
            _dapperHelper = dapperHelper;
            
        }
      

        public TEntity Add(TEntity entity)
        {
            var h =_dapperHelper.Insert(entity);
            return entity;
        }

        public List<TEntity> AddRange(List<TEntity> items)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(List<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
           var dd= ExpressionExtensions.ToMSSqlString(filter);
            var k = filter;
            throw new NotImplementedException();
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
           return _dapperHelper.GetAll(filter).ToList();
        }

        public TEntity Update(TEntity entity)
        {
            _dapperHelper.Update(entity);
            return entity;
        }
    }
       
}
