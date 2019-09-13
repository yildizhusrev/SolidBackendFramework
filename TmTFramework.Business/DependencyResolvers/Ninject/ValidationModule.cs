using Ninject.Modules;

namespace GolyakaSinav.DatabaseSinav.Business.DependencyResolvers.Ninject
{
    public class ValidationModule : NinjectModule
    {
        public override void Load()
        {
           //validasyon ile ilegili dependency injectiın yapılacak yer

            //Bind<Ivalidator<Product>>().To<ProdactValidator>().Insingletdoscope();
        }
    }
}
