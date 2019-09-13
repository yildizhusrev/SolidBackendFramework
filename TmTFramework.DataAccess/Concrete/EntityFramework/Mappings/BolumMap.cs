using TmTFramework.Entities.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace TmTFramework.DataAccess.Concrete.EntityFramework.Mappings
{
    public class BolumMap : EntityTypeConfiguration<Arac>
    {
        public BolumMap()
        {
            ToTable(@"Bolum", @"dbo");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Adi");
        }
    }
}
