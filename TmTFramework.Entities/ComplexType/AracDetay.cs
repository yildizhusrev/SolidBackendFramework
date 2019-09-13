using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TmTFramework.Entities.ComplexType
{
    public class AracDetay
    {
        /// <summary>
        /// Arac Id
        /// </summary>
        public  Guid Id { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Yil { get; set; }
        public string MusteriAdi { get; set; }
        public string Plaka { get; set; }
        public int ServisAdet { get; set; }



    }
}
