
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
    public class UrunManager:IUrunService
    {
       private IUrunDal _urunDal;

       public UrunManager(IUrunDal urunDal)
       {
           _urunDal = urunDal;
       }

       //[CacheAspect(typeof(MemoryCacheManager),120)]
       public List<Urun> GetAll()
       {
           return _urunDal.GetList();
       }

       public Urun GetById(Guid id)
       {
           return _urunDal.Get(h => h.Id == id);
       }



       //[FluentValidationAspect(typeof(Microsoft.VisualStudio.TextTemplating8419A0B83E38449666535B438C8B65A520BAABB17F52B9D39F3CBF25BABBEEA00902FAE3481D6B0E3EF3F101D2A87BED58B273A73F08F8254A58C876398A7C04.GeneratedTextTransformation+DatabaseTableValidatior))]
       //[CacheRemoAspect(typeof(MemoryCacheManager))]
       public Urun Add(Urun urun)
       {
            //ValidatorTool.FluentValidate( new Microsoft.VisualStudio.TextTemplating8419A0B83E38449666535B438C8B65A520BAABB17F52B9D39F3CBF25BABBEEA00902FAE3481D6B0E3EF3F101D2A87BED58B273A73F08F8254A58C876398A7C04.GeneratedTextTransformation+DatabaseTableValidatior(), Urun);
           return _urunDal.Add(urun);
       }

        //[FluentValidationAspect(typeof(UrunValidatior))]
        public Urun Update(Urun urun)
        {
            //ValidatorTool.FluentValidate(new Microsoft.VisualStudio.TextTemplating8419A0B83E38449666535B438C8B65A520BAABB17F52B9D39F3CBF25BABBEEA00902FAE3481D6B0E3EF3F101D2A87BED58B273A73F08F8254A58C876398A7C04.GeneratedTextTransformation+DatabaseTableValidatior(), Urun);
            return _urunDal.Update(urun);
        }

		 public void Delete(Urun urun)
        {
            _urunDal.Delete(urun);
        }
    }

}
