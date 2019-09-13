using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TmTFramework.Entities.Concrete;

namespace TmTFramework.DataAccess.Concrete.EntityFramework.Mappings
{
    public class MusteriMap:EntityTypeConfiguration<Musteri>
    {
        public MusteriMap()
        {
            ToTable(@"Musteri", @"dbo");
            HasKey(x => x.Id);
            Property(x => x.AdSoyad).HasColumnName("AdSoyad");
            Property(x => x.Telefon).HasColumnName("Telefon");
            Property(x => x.Adres).HasColumnName("Adres");
            Property(x => x.VergiDairesi).HasColumnName("VergiDairesi");
            Property(x => x.VergiNo).HasColumnName("VergiNo");
            Property(x => x.Email).HasColumnName("Email");

        }
    }
}
