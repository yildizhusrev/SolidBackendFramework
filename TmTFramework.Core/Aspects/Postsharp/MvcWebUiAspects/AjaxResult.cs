using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TmTFramework.Core.Aspects.Postsharp.MvcWebUiAspects
{
    public class AjaxResult
    {
        public string mesaj { get; set; } = "İşlem başarıyla gerçekleştirildi";
        public bool sonuc { get; set; } = true;
        public object data { get; set; }
    }
}
