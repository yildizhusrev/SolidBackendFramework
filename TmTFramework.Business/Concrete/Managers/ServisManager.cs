
// Code generated by a template Hüsrev YILDIZ
//using TmTFramework.Core.Aspects.Postsharp.ChacheAspects;
//using TmTFramework.Core.Aspects.Postsharp.ValidationAspects;
//using TmTFramework.Core.CrossCuttingConcerns.Cashing.Microsoft;
//using TmTFramework.Business.ValidationRules.FluentValidation;
using TmTFramework.Core.Aspects.Postsharp.AuthoritationAspects;
using TmTFramework.Business.Abstract;
using TmTFramework.DataAccess.Abstract;
using TmTFramework.Entities.Concrete;
using System.Collections.Generic;
using System;
using TmTFramework.Entities.ComplexType;

namespace TmTFramework.Business.Concrete.Managers
{


    [SecuredOperation]
    public class ServisManager:IServisService
    {
       private IServisDal _servisDal;

       public ServisManager(IServisDal servisDal)
       {
           _servisDal = servisDal;
       }

       //[CacheAspect(typeof(MemoryCacheManager),120)]
       public List<Servis> GetAll()
       {
           return _servisDal.GetList();
       }

       public Servis GetById(Guid id)
       {
           return _servisDal.Get(h => h.Id == id);
       }



       //[FluentValidationAspect(typeof(Microsoft.VisualStudio.TextTemplating8419A0B83E38449666535B438C8B65A520BAABB17F52B9D39F3CBF25BABBEEA00902FAE3481D6B0E3EF3F101D2A87BED58B273A73F08F8254A58C876398A7C04.GeneratedTextTransformation+DatabaseTableValidatior))]
       //[CacheRemoAspect(typeof(MemoryCacheManager))]
       public Servis Add(Servis servis)
       {
            //ValidatorTool.FluentValidate( new Microsoft.VisualStudio.TextTemplating8419A0B83E38449666535B438C8B65A520BAABB17F52B9D39F3CBF25BABBEEA00902FAE3481D6B0E3EF3F101D2A87BED58B273A73F08F8254A58C876398A7C04.GeneratedTextTransformation+DatabaseTableValidatior(), Servis);
           return _servisDal.Add(servis);
       }

        //[FluentValidationAspect(typeof(ServisValidatior))]
        public Servis Update(Servis servis)
        {
            //ValidatorTool.FluentValidate(new Microsoft.VisualStudio.TextTemplating8419A0B83E38449666535B438C8B65A520BAABB17F52B9D39F3CBF25BABBEEA00902FAE3481D6B0E3EF3F101D2A87BED58B273A73F08F8254A58C876398A7C04.GeneratedTextTransformation+DatabaseTableValidatior(), Servis);
            return _servisDal.Update(servis);
        }

		 public void Delete(Servis servis)
        {
            _servisDal.Delete(servis);
        }

        [SecuredOperation(Roles ="Admin")]
        public List<ServisDetails> GetServisDetails()
        {
            return _servisDal.GetServisDetails();
        }

        public List<Servis> AddRange(List<Servis> servisler)
        {
            return _servisDal.AddRange(servisler);
        }

        public ServisDetails GetServisDetailsById(Guid id)
        {
            return _servisDal.GetServisDetailsById(id);
        }
    }

}
