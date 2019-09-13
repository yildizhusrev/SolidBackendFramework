using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TmTFramework.MvcWebUI.Filters;


namespace TmTFramework.MvcWebUI.Controllers
{
    public class HomeController : Controller
    {
        [SecurityFilter]
        public ActionResult Index()
        {
            return View();
        }
    }
}