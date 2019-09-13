using TmTFramework.Entities.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace TmTFramework.DataAccess.Concrete.EntityFramework.Mappings
{
    public class AkademikPersonelMap : EntityTypeConfiguration<Musteri>
    {
        public AkademikPersonelMap()
        {
            ToTable(@"AkademikPersonel", @"dbo");
            HasKey(x => x.Id);

            Property(x => x.AdSoyad).HasColumnName("Adi");
            Property(x => x.AdSoyad).HasColumnName("Soyadi");
            

        }
    }
}
