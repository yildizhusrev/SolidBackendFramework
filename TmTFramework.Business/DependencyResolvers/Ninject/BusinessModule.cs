using TmTFramework.Core.DataAccess;
using TmTFramework.Core.DataAccess.EntityFramework;
using TmTFramework.Business.Abstract;
using TmTFramework.Business.Concrete.Managers;
using TmTFramework.DataAccess.Abstract;
using TmTFramework.DataAccess.Concrete.EntityFramework;
using Ninject.Modules;
using System.Data.Entity;
using TmTFramework.DataAccess.Concrete.Dapper;

namespace TmTFramework.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            //Custom Services
            Bind<IAracBakimService>().To<AracBakimService>().InSingletonScope();


            Bind<IAracService>().To<AracManager>().InSingletonScope();
            Bind<IAracDal>().To<EfAracDal>();
            Bind<IAracArizaKayitService>().To<AracArizaKayitManager>().InSingletonScope();
            Bind<IAracArizaKayitDal>().To<EfAracArizaKayitDal>();
            Bind<IArizaKategoriService>().To<ArizaKategoriManager>().InSingletonScope();
            Bind<IArizaKategoriDal>().To<EfArizaKategoriDal>();


            Bind<IMusteriService>().To<MusteriManager>().InSingletonScope();
            //Bind<IMusteriDal>().To<EfMusteriDal>();
            Bind<IMusteriDal>().To<DapperMusteriDal>();


            Bind<IPersonelService>().To<PersonelManager>().InSingletonScope();
            Bind<IPersonelDal>().To<EfPersonelDal>();
            Bind<IServisService>().To<ServisManager>().InSingletonScope();
            Bind<IServisDal>().To<EfServisDal>();

            Bind<IUrunService>().To<UrunManager>().InSingletonScope();
            Bind<IUrunDal>().To<EfUrunDal>();

            Bind<IRoleService>().To<RoleManager>().InSingletonScope();
            Bind<IRoleDal>().To<EfRoleDal>();

            Bind<IUserRoleService>().To<UserRoleManager>().InSingletonScope();
            Bind<IUserRoleDal>().To<EfUserRoleDal>();

            Bind<IUsersService>().To<UsersManager>().InSingletonScope();
            Bind<IUsersDal>().To<EfUsersDal>();





            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepository<>));
            Bind<DbContext>().To<TMTServisContext>();
        }
    }
}
