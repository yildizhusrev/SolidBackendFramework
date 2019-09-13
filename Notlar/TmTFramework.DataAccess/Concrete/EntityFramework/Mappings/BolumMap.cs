using TmTFramework.Entities.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace TmTFramework.DataAccess.Concrete.EntityFramework.Mappings
{
    public class BolumMap : EntityTypeConfiguration<Bolum>
    {
        public BolumMap()
        {
            ToTable(@"Bolum", @"dbo");
            HasKey(x => x.Id);
            Property(x => x.Adi).HasColumnName("Adi");
        }
    }
}
