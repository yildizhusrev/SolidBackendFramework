
// Code generated by a template
using System;
using System.Collections.Generic;
using TmTFramework.Entities.ComplexType;
using TmTFramework.Entities.Concrete;

namespace TmTFramework.Business.Abstract
{

   

    public interface IServisService
    {
        List<Servis> GetAll();

        Servis GetById(Guid id);

        Servis Add(Servis servis);

        List<Servis> AddRange(List<Servis> servisler);

        Servis Update(Servis servis);
        
		void Delete(Servis servis);

        List<ServisDetails> GetServisDetails();

        ServisDetails GetServisDetailsById(Guid id);
    }

}