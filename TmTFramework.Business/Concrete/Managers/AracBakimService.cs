using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TmTFramework.Business.Abstract;
using TmTFramework.Core.Aspects.Postsharp.AuthoritationAspects;
using TmTFramework.Core.Aspects.Postsharp.TransactionAspects;
using TmTFramework.DataAccess.Abstract;
using TmTFramework.Entities.Concrete;

namespace TmTFramework.Business.Concrete.Managers
{
    [SecuredOperation]
    public class AracBakimService: IAracBakimService
    {
        private IServisDal _servisDal;
        private IAracArizaKayitDal _aracArizaKayitDal;
        
        public AracBakimService(IServisDal servisDal,  IAracArizaKayitDal aracArizaKayitDal)
        {
            _servisDal = servisDal;
            _aracArizaKayitDal = aracArizaKayitDal;
           
        }


        [TransactionScopeAspect]
        public void AddServisAndArizaKayit(Servis servis, List<AracArizaKayit> arizalar)
        {
            _servisDal.Add(servis);
            _aracArizaKayitDal.AddRange(arizalar);


            
        }

        [TransactionScopeAspect]
        public void DeleteServiceWithVehicleFailures(Guid ServisId)
        {
            var silinecek =_aracArizaKayitDal.GetList(h=>h.ServisId==ServisId);
  
                _aracArizaKayitDal.DeleteRange(silinecek);

            _servisDal.Delete(_servisDal.Get(h=>h.Id==ServisId));
        }

        [TransactionScopeAspect]
        public void DeleteServiceWithVehicleFailures(Servis servis, List<AracArizaKayit> arizalar)
        {
            _aracArizaKayitDal.DeleteRange(arizalar);
            _servisDal.Delete(servis);

        }
    }
}
