using TmTFramework.Core.Entities;

namespace TmTFramework.Entities.Concrete
{
    public class Ders:IEntity
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Kodu { get; set; }
        public bool AktifMi { get; set; }

    }
}
