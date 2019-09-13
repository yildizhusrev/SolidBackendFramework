using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TmTFramework.Entities.Concrete;

namespace TmTFramework.Entities.ComplexType
{
    
    public class ServisDetails
    {
       
        public Guid Id { get; set; }
        public Guid AracId { get; set; }
        public DateTime ServisZamani { get; set; }
        public string AracPlaka { get; set; }

        public Musteri ServisMusterisi { get; set; }


        public List<ServisAracArizaKayit> AracArizaKayitlari { get; set; }

        public ServisDurumu ServisDurumu
        {
            get
            {
                if (AracArizaKayitlari.Any(h => h.PersonelId == null))
                    return ServisDurumu.Beklemede;
                if (AracArizaKayitlari.Any(h => h.ArizaTamamlandiMi == false))
                    return ServisDurumu.Islemde;
                return ServisDurumu.Tamamlandi;
            }

        }
    }

    public class ServisAracArizaKayit
    {
        public Guid AracArizaKayitId { get; set; }
        public Guid? PersonelId { get; set; }
        public bool ArizaTamamlandiMi { get; set; }
        public Guid ArizaKategoriId { get; set; }
        public string ArizaKategoriAdi { get; set; }

    }

    public enum ServisDurumu
    {
        Tamamlandi,
        Islemde,
        Beklemede
    }
}
