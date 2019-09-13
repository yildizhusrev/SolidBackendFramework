
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

namespace TmTFramework.Business.Concrete.Managers
{
    [SecuredOperation]
    public class AracArizaKayitManager:IAracArizaKayitService
    {
       private IAracArizaKayitDal _aracarizakayitDal;

       public AracArizaKayitManager(IAracArizaKayitDal aracarizakayitDal)
       {
           _aracarizakayitDal = aracarizakayitDal;
       }

       //[CacheAspect(typeof(MemoryCacheManager),120)]
       public List<AracArizaKayit> GetAll()
       {
           return _aracarizakayitDal.GetList();
       }

       public List<AracArizaKayit> GetListByServisId(Guid id)
       {
           return _aracarizakayitDal.GetList(h => h.ServisId == id);
       }

        public AracArizaKayit GetById(Guid id)
       {
           return _aracarizakayitDal.Get(h => h.Id == id);
       }



       //[FluentValidationAspect(typeof(Microsoft.VisualStudio.TextTemplating8419A0B83E38449666535B438C8B65A520BAABB17F52B9D39F3CBF25BABBEEA00902FAE3481D6B0E3EF3F101D2A87BED58B273A73F08F8254A58C876398A7C04.GeneratedTextTransformation+DatabaseTableValidatior))]
       //[CacheRemoAspect(typeof(MemoryCacheManager))]
       public AracArizaKayit Add(AracArizaKayit aracarizakayit)
       {
            //ValidatorTool.FluentValidate( new Microsoft.VisualStudio.TextTemplating8419A0B83E38449666535B438C8B65A520BAABB17F52B9D39F3CBF25BABBEEA00902FAE3481D6B0E3EF3F101D2A87BED58B273A73F08F8254A58C876398A7C04.GeneratedTextTransformation+DatabaseTableValidatior(), AracArizaKayit);
           return _aracarizakayitDal.Add(aracarizakayit);
       }

        //[FluentValidationAspect(typeof(AracArizaKayitValidatior))]
        public AracArizaKayit Update(AracArizaKayit aracarizakayit)
        {
            //ValidatorTool.FluentValidate(new Microsoft.VisualStudio.TextTemplating8419A0B83E38449666535B438C8B65A520BAABB17F52B9D39F3CBF25BABBEEA00902FAE3481D6B0E3EF3F101D2A87BED58B273A73F08F8254A58C876398A7C04.GeneratedTextTransformation+DatabaseTableValidatior(), AracArizaKayit);
            return _aracarizakayitDal.Update(aracarizakayit);
        }

		 public void Delete(AracArizaKayit aracarizakayit)
         {
            _aracarizakayitDal.Delete(aracarizakayit);
         }

         public void DeleteRange(List<AracArizaKayit> araclar)
         {
             _aracarizakayitDal.DeleteRange(araclar);
         }

         public List<AracArizaKayit> AddRange(List<AracArizaKayit> aracArizaKayitlari)
        {
            return _aracarizakayitDal.AddRange(aracArizaKayitlari);
        }
    }

}
