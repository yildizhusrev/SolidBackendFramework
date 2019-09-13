using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TmTFramework.Entities.Concrete;

namespace TmTFramework.Business.Abstract
{
    public interface IAracBakimService
    {
        void AddServisAndArizaKayit(Servis servis, List<AracArizaKayit> arizalar);

        /// <summary>
        /// servis Id sini alır ve servis kaydı ile kayda bağlı arızalari siler
        /// </summary>
        /// <param name="ServisId"></param>
        void DeleteServiceWithVehicleFailures(Guid ServisId);

        /// <summary>
        /// Servivi Ariza Kayıtları ile beraber siler
        /// </summary>
        /// <param name="servis"></param>
        /// <param name="arizalar"></param>
        void DeleteServiceWithVehicleFailures(Servis servis, List<AracArizaKayit> arizalar);
    }
}
