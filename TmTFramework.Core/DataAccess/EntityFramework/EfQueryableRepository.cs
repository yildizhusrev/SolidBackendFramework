using TmTFramework.Core.Entities;
using System.Data.Entity;
using System.Linq;

namespace TmTFramework.Core.DataAccess.EntityFramework
{
    public class EfQueryableRepository<T>:IQueryableRepository<T> where T:class ,IEntity,new ()

    {
        private DbContext _context;
        private IDbSet<T> _entities;
        public EfQueryableRepository( DbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Table => this.Entites;

        protected virtual IDbSet<T> Entites
        {
            get { return _entities ?? (_entities = _context.Set<T>()); }
        }
    }
}
