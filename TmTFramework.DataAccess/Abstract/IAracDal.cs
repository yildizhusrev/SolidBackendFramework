
// Code generated by a template

using System;
using System.Collections.Generic;
using TmTFramework.Core.DataAccess;
using TmTFramework.Entities.ComplexType;
using TmTFramework.Entities.Concrete;

namespace TmTFramework.DataAccess.Abstract
{
    public interface IAracDal:IEntityRepository<Arac>
    {
        AracKayitBilgi GetCarInfoForAd(Guid id);
        List<AracDetay> GetAllWithDetail();
    }

}
