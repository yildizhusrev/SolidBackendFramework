using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TmTFramework.Entities.Concrete;

namespace TmTFramework.DataAccess.Concrete.EntityFramework.Mappings
{
    class DersMap:EntityTypeConfiguration<Ders>
    {
        public DersMap()
        {
            ToTable(@"Ders", @"dbo");
            HasKey(x => x.Id);

            Property(x => x.Adi).HasColumnName("Adi");
            Property(x => x.Kodu).HasColumnName("Kodu");
            Property(x => x.AktifMi).HasColumnName("AktifMi");

        }
    }
}
