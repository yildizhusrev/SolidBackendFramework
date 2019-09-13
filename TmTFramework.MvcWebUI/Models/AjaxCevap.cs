using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TmTFramework.MvcWebUI.Models
{
    public class AjaxCevap
    {
        public string mesaj { get; set; } = "İşlem başarıyla gerçekleştirildi";
        public bool sonuc { get; set; } = true;
        public object data { get; set; }
    }
}