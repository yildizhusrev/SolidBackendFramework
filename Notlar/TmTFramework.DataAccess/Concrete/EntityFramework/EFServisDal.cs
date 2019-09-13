
// Code generated by a template
using TmTFramework.Core.DataAccess.EntityFramework;
using TmTFramework.DataAccess.Abstract;
using TmTFramework.Entities.Concrete;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using TmTFramework.Entities.ComplexType;
using System;

namespace TmTFramework.DataAccess.Concrete.EntityFramework
{


    //public class EfBolumDal : EfEntityRepositoryBase<Bolum, TMTServisContext>,IBolumDal
    public class EfServisDal : EfEntityRepositoryBase<Servis, TMTServisContext>, IServisDal
    {
        public List<ServisDetails> GetServisDetails()
        {
            try
            {

           
            using (TMTServisContext context = new TMTServisContext())
            {
                    var result = (from s in context.Servis
                              join a in context.Arac on s.AracId equals a.Id 
                              join ak in context.AracArizaKayit on s.Id equals ak.ServisId into sAracArizaKayitlari
                              select new ServisDetails()
                              {
                                  Id = s.Id,
                                  AracId = s.AracId,
                                  ServisZamani = s.ServisZamani,
                                  AracPlaka = a.Plaka,
                                  AracArizaKayitlari=sAracArizaKayitlari.Select(h=> 
                                  new ServisAracArizaKayit() {
                                      AracArizaKayitId = h.Id,
                                      ArizaKategoriId =h.ArizaKategoriId,
                                      ArizaKategoriAdi = context.ArizaKategori.FirstOrDefault(aktg => aktg.Id==h.ArizaKategoriId).Adi,
                                      ArizaTamamlandiMi =h.ArizaTamamlandiMi,
                                      PersonelId =h.PersonelId }).ToList()

                              }).ToList();

                

                return result;
            }
            }
            catch (System.Exception ex)
            {

                throw new Exception(ex.Message + ex.InnerException?.Message);
            }
        }
    }

}
