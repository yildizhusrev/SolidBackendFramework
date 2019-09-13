
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


   
    public class UsersManager:IUsersService
    {
       private IUsersDal _usersDal;

       public UsersManager(IUsersDal usersDal)
       {
           _usersDal = usersDal;
       }

       //[CacheAspect(typeof(MemoryCacheManager),120)]
       public List<User> GetAll()
       {
           return _usersDal.GetList();
       }

       public User GetById(Guid id)
       {
           return _usersDal.Get(h => h.Id == id);
       }



       //[FluentValidationAspect(typeof(Microsoft.VisualStudio.TextTemplating28D969267979CD858E05D2BE5C0F6ADD2B952A5E4B5839D76153D9D05D4F46628B4E7B0E544A47E640C6C022B4FE46EE0D2694C76AACC0B5253C56B7E99D54CF.GeneratedTextTransformation+DatabaseTableValidatior))]
       //[CacheRemoAspect(typeof(MemoryCacheManager))]
       public User Add(User users)
       {
            //ValidatorTool.FluentValidate( new Microsoft.VisualStudio.TextTemplating28D969267979CD858E05D2BE5C0F6ADD2B952A5E4B5839D76153D9D05D4F46628B4E7B0E544A47E640C6C022B4FE46EE0D2694C76AACC0B5253C56B7E99D54CF.GeneratedTextTransformation+DatabaseTableValidatior(), Users);
           return _usersDal.Add(users);
       }

        //[FluentValidationAspect(typeof(UsersValidatior))]
        public User Update(User users)
        {
            //ValidatorTool.FluentValidate(new Microsoft.VisualStudio.TextTemplating28D969267979CD858E05D2BE5C0F6ADD2B952A5E4B5839D76153D9D05D4F46628B4E7B0E544A47E640C6C022B4FE46EE0D2694C76AACC0B5253C56B7E99D54CF.GeneratedTextTransformation+DatabaseTableValidatior(), Users);
            return _usersDal.Update(users);
        }

		 public void Delete(User users)
        {
            _usersDal.Delete(users);
        }

        public User GetByUserNameAndPassword(string userName, string password)
        {
           return _usersDal.Get(x => x.UserName == userName && x.Password == password);
        }

        public string[] GetUserRoles(User user)
        {
            return _usersDal.GetUserRoles(user);
        }
    }

}