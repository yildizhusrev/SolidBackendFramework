using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace TmTFramework.MvcWebUI.Filters
{
    public class CheckParameterFilter : ActionFilterAttribute
    {
        public string Parameter { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var id = filterContext.ActionParameters;
            if (id.Count>0)
            {
                if (string.IsNullOrEmpty(Parameter))
                {
                    if(id["id"]==null)
                        filterContext.Result=new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                else
                {
                    if (id[Parameter] == null)
                        filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}