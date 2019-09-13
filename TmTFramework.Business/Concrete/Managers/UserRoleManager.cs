
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


  
    public class UserRoleManager:IUserRoleService
    {
       private IUserRoleDal _userroleDal;

       public UserRoleManager(IUserRoleDal userroleDal)
       {
           _userroleDal = userroleDal;
       }

       //[CacheAspect(typeof(MemoryCacheManager),120)]
       public List<UserRole> GetAll()
       {
           return _userroleDal.GetList();
       }

       public UserRole GetById(Guid id)
       {
           return _userroleDal.Get(h => h.Id == id);
       }



       //[FluentValidationAspect(typeof(Microsoft.VisualStudio.TextTemplating28D969267979CD858E05D2BE5C0F6ADD2B952A5E4B5839D76153D9D05D4F46628B4E7B0E544A47E640C6C022B4FE46EE0D2694C76AACC0B5253C56B7E99D54CF.GeneratedTextTransformation+DatabaseTableValidatior))]
       //[CacheRemoAspect(typeof(MemoryCacheManager))]
       public UserRole Add(UserRole userrole)
       {
            //ValidatorTool.FluentValidate( new Microsoft.VisualStudio.TextTemplating28D969267979CD858E05D2BE5C0F6ADD2B952A5E4B5839D76153D9D05D4F46628B4E7B0E544A47E640C6C022B4FE46EE0D2694C76AACC0B5253C56B7E99D54CF.GeneratedTextTransformation+DatabaseTableValidatior(), UserRole);
           return _userroleDal.Add(userrole);
       }

        //[FluentValidationAspect(typeof(UserRoleValidatior))]
        public UserRole Update(UserRole userrole)
        {
            //ValidatorTool.FluentValidate(new Microsoft.VisualStudio.TextTemplating28D969267979CD858E05D2BE5C0F6ADD2B952A5E4B5839D76153D9D05D4F46628B4E7B0E544A47E640C6C022B4FE46EE0D2694C76AACC0B5253C56B7E99D54CF.GeneratedTextTransformation+DatabaseTableValidatior(), UserRole);
            return _userroleDal.Update(userrole);
        }

		 public void Delete(UserRole userrole)
        {
            _userroleDal.Delete(userrole);
        }
    }

}