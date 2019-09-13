using System.Linq;
using TmTFramework.Core.Entities;

namespace TmTFramework.Core.DataAccess
{
    public interface IQueryableRepository<T> where T:class,IEntity,new()
    {
        IQueryable<T> Table {get;}
    }
}
