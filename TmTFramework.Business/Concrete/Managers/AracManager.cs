
// Code generated by a template Hüsrev YILDIZ
//using TmTFramework.Core.Aspects.Postsharp.ChacheAspects;
//using TmTFramework.Core.Aspects.Postsharp.ValidationAspects;
//using TmTFramework.Core.CrossCuttingConcerns.Cashing.Microsoft;
//using TmTFramework.Business.ValidationRules.FluentValidation;
using TmTFramework.Business.Abstract;
using TmTFramework.DataAccess.Abstract;
using TmTFramework.Entities.Concrete;
using System.Collections.Generic;
using System;
using TmTFramework.Core.Aspects.Postsharp.AuthoritationAspects;
using TmTFramework.Entities.ComplexType;

namespace TmTFramework.Business.Concrete.Managers
{


    [SecuredOperation]
    public class AracManager:IAracService
    {
       private IAracDal _aracDal;

       public AracManager(IAracDal aracDal)
       {
           _aracDal = aracDal;
       }

       //[CacheAspect(typeof(MemoryCacheManager),120)]
       public List<Arac> GetAll()
       {
           return _aracDal.GetList();
       }

       public Arac GetById(Guid id)
       {
           return _aracDal.Get(h => h.Id == id);
       }



       //[FluentValidationAspect(typeof(Microsoft.VisualStudio.TextTemplating8419A0B83E38449666535B438C8B65A520BAABB17F52B9D39F3CBF25BABBEEA00902FAE3481D6B0E3EF3F101D2A87BED58B273A73F08F8254A58C876398A7C04.GeneratedTextTransformation+DatabaseTableValidatior))]
       //[CacheRemoAspect(typeof(MemoryCacheManager))]
       public Arac Add(Arac arac)
       {
            //ValidatorTool.FluentValidate( new Microsoft.VisualStudio.TextTemplating8419A0B83E38449666535B438C8B65A520BAABB17F52B9D39F3CBF25BABBEEA00902FAE3481D6B0E3EF3F101D2A87BED58B273A73F08F8254A58C876398A7C04.GeneratedTextTransformation+DatabaseTableValidatior(), Arac);
           return _aracDal.Add(arac);
       }

        //[FluentValidationAspect(typeof(AracValidatior))]
        public Arac Update(Arac arac)
        {
            //ValidatorTool.FluentValidate(new Microsoft.VisualStudio.TextTemplating8419A0B83E38449666535B438C8B65A520BAABB17F52B9D39F3CBF25BABBEEA00902FAE3481D6B0E3EF3F101D2A87BED58B273A73F08F8254A58C876398A7C04.GeneratedTextTransformation+DatabaseTableValidatior(), Arac);
            return _aracDal.Update(arac);
        }

		 public void Delete(Arac arac)
        {
            _aracDal.Delete(arac);
        }

        public AracKayitBilgi GetCarInfoForAd(Guid id)
        {
            return  _aracDal.GetCarInfoForAd(id);
        }

        public List<AracDetay> GetAllWithDetail()
        {
            return _aracDal.GetAllWithDetail();
        }
    }

}
