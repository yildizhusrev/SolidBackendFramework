

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TmTFramework.Business.Abstract;
using TmTFramework.Core.Aspects.Postsharp.MvcWebUiAspects;
using TmTFramework.Entities.Concrete;
using TmTFramework.MvcWebUI.Filters;
using TmTFramework.MvcWebUI.Models;

namespace TmTFramework.MvcWebUI.Controllers
{
    public class UrunsController : Controller
    {

        private IUrunService _UrunService;
        public UrunsController(IUrunService UrunService)
        {
            _UrunService = UrunService;

        }
        #region Index Operation
        // GET: Musteri
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult AjaxIndex()
        {
            return View(_UrunService.GetAll());
        }
        #endregion

        #region Details Operations
        [CheckParameterFilter]
        public ActionResult Details(Guid id)
        {
            Urun Urun = _UrunService.GetById(id);
            if (Urun == null)
            {
                return HttpNotFound();
            }
            return View(Urun);
        }

        [FormCevapAspect]
        public JsonResult DetailsAjax(Guid id)
        {
            Urun Urun = _UrunService.GetById(id);
            if (Urun == null)
                return Json(HttpNotFound().StatusDescription);
            return Json(Urun);
        }
        #endregion

        #region Create Operation
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormCevapAspect]
        public JsonResult Create(Urun Urun)
        {

            Urun.Id = Guid.NewGuid();
            _UrunService.Add(Urun);
            return Json(null);
        }

        #endregion

        #region Edit Operation
        [CheckParameterFilter]
        public ActionResult Edit(Guid id)
        {
            Urun Urun = _UrunService.GetById(id);
            if (Urun == null)
                return HttpNotFound();

            return View(Urun);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormCevapAspect]
        public JsonResult Edit(Urun Urun)
        {
            _UrunService.Update(Urun);
            return Json(null);
        }
        #endregion

        #region Delete Operatin
        [CheckParameterFilter]
        public ActionResult Delete(Guid id)
        {

            Urun Urun = _UrunService.GetById(id);
            if (Urun == null)
            {
                return HttpNotFound();
            }
            return View(Urun);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [FormCevapAspect]
        [CheckParameterFilter]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _UrunService.Delete(_UrunService.GetById(id));
            return Json(null);
        }
        #endregion
    }
}
