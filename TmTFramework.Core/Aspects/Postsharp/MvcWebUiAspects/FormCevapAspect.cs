using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using PostSharp.Aspects;

namespace TmTFramework.Core.Aspects.Postsharp.MvcWebUiAspects
{
    [Serializable]
    public class FormCevapAspect : OnMethodBoundaryAspect
    {

        public override void OnSuccess(MethodExecutionArgs args)
        {
            JsonResult result = new JsonResult();
            result = (JsonResult)args.ReturnValue;

            if (result.Data == null)
            {
                result.Data = new AjaxResult()
                {
                    mesaj = "İşlem Başarılı"
                };
            }
            else
            {
                result.Data = new AjaxResult()
                {
                    mesaj = result.Data.ToString(),
                    data = result.Data
                };
            }

            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            args.ReturnValue = result;
        }


        public override void OnException(MethodExecutionArgs args)
        {
            //hataları loglama- mail atma gib işlemler
            if (true)
            {
                //EmailSender emailsender = new EmailSender();
                //emailsender.Send(args.Exception, "WARNING");

            }

            JsonResult result = new JsonResult();
            result.Data = new AjaxResult() { sonuc = false, mesaj = args.Exception.Message };
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            args.FlowBehavior = FlowBehavior.Return;
            args.ReturnValue = result;


        }

    }
}
