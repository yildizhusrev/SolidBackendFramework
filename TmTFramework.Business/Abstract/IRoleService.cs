
// Code generated by a template
using System;
using System.Collections.Generic;
using TmTFramework.Entities.Concrete;

namespace TmTFramework.Business.Abstract
{

   

    public interface IRoleService
    {
        List<Role> GetAll();

        Role GetById(Guid id);

        Role Add(Role role);

        Role Update(Role role);
        
		void Delete(Role role);
	}

}
