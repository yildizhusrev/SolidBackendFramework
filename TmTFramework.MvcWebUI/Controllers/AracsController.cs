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
    public class AracsController : Controller
    {

        private IAracService _AracService;
        private IMusteriService _musteriService;
        public AracsController(IAracService AracService, IMusteriService musteriService)
        {
            _AracService = AracService;
            _musteriService = musteriService;
        }
        #region Index Operation
        // GET: Musteri
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult AjaxIndex()
        {
            return View(_AracService.GetAllWithDetail());
        }
#endregion

        #region Details Operations
        [CheckParameterFilter]
        public ActionResult Details(Guid id)
        {
            Arac arac = _AracService.GetById(id);
            if (arac == null)
            {
                return HttpNotFound();
            }
            return View(arac);
        }

        [FormCevapAspect]
        public JsonResult DetailsAjax(Guid id)
        {
            Arac arac = _AracService.GetById(id);
            if (arac == null)
                return Json(HttpNotFound().StatusDescription);
            return Json(arac);
        }
        #endregion

        #region Create Operation
        public ActionResult Create()
        {
            ViewBag.MusteriId = new SelectList(_musteriService.GetAll(), "Id", "AdSoyad");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormCevapAspect]
        public JsonResult Create(Arac arac)
        {

            arac.Id = Guid.NewGuid();
            _AracService.Add(arac);
            return Json(null);
        }

        #endregion

        #region Edit Operation
        [CheckParameterFilter]
        public ActionResult Edit(Guid id)
        {
            Arac arac = _AracService.GetById(id);
            if (arac == null)
                return HttpNotFound();
            ViewBag.MusteriId = new SelectList(_musteriService.GetAll(), "Id", "AdSoyad",arac.MusteriId);

            return View(arac);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormCevapAspect]
        public JsonResult Edit(Arac arac)
        {
            _AracService.Update(arac);
            return Json(null);
        }
        #endregion

        #region Delete Operatin
        [CheckParameterFilter]
        public ActionResult Delete(Guid id)
        {

            var arac = _AracService.GetCarInfoForAd(id);
            if (arac == null)
            {
                return HttpNotFound();
            }
            return View(arac);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [FormCevapAspect]
        [CheckParameterFilter]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _AracService.Delete(_AracService.GetById(id));
            return Json(null);
        }
        #endregion
    }
}