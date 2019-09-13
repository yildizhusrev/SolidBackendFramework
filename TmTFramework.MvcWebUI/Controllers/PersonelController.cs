

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
    public class PersonelsController : Controller
    {

        private IPersonelService _PersonelService;
      
        public PersonelsController(IPersonelService PersonelService)
        {
            _PersonelService = PersonelService;

        }
        #region Index Operation
        // GET: Musteri
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult AjaxIndex()
        {
            return View(_PersonelService.GetAll());
        }
        #endregion

        #region Details Operations
        [CheckParameterFilter]
        public ActionResult Details(Guid id)
        {
            Personel Personel = _PersonelService.GetById(id);
            if (Personel == null)
            {
                return HttpNotFound();
            }
            return View(Personel);
        }

        [FormCevapAspect]
        public JsonResult DetailsAjax(Guid id)
        {
            Personel Personel = _PersonelService.GetById(id);
            if (Personel == null)
                return Json(HttpNotFound().StatusDescription);
            return Json(Personel);
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
        public JsonResult Create(Personel Personel)
        {

            Personel.Id = Guid.NewGuid();
            _PersonelService.Add(Personel);
            return Json(null);
        }

        #endregion

        #region Edit Operation
        [CheckParameterFilter]
        public ActionResult Edit(Guid id)
        {
            Personel Personel = _PersonelService.GetById(id);
            if (Personel == null)
                return HttpNotFound();

            return View(Personel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormCevapAspect]
        public JsonResult Edit(Personel Personel)
        {
            _PersonelService.Update(Personel);
            return Json(null);
        }
        #endregion

        #region Delete Operatin
        [CheckParameterFilter]
        public ActionResult Delete(Guid id)
        {

            Personel Personel = _PersonelService.GetById(id);
            if (Personel == null)
            {
                return HttpNotFound();
            }
            return View(Personel);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [FormCevapAspect]
        [CheckParameterFilter]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _PersonelService.Delete(_PersonelService.GetById(id));
            return Json(null);
        }
        #endregion
    }
}
