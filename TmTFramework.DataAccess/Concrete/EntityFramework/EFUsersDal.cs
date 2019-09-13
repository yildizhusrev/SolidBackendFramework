
// Code generated by a template
using TmTFramework.Core.DataAccess.EntityFramework;
using TmTFramework.DataAccess.Abstract;
using TmTFramework.Entities.Concrete;
using System.Linq;

namespace TmTFramework.DataAccess.Concrete.EntityFramework
{


    //public class EfBolumDal : EfEntityRepositoryBase<Bolum, TMTServisContext>,IBolumDal
    public class EfUsersDal : EfEntityRepositoryBase<User, TMTServisContext>, IUsersDal
    {
        public string[] GetUserRoles(User user)
        {
            using (TMTServisContext context = new TMTServisContext())
            {
                var result = (from u in context.Users
                              join ur in context.UserRole on u.Id equals ur.UserId
                              join r in context.Role on ur.RoleId equals r.Id
                              select r.Name).ToArray();
                return result;
            }
        }
    }

}
