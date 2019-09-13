using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TmTFramework.Business.Abstract;
using TmTFramework.Core.Aspects.Postsharp.MvcWebUiAspects;
using TmTFramework.Entities.Concrete;
using TmTFramework.MvcWebUI.Models;

namespace TmTFramework.MvcWebUI.Controllers
{
    public class ArizaKategorisController : Controller
    {

        private readonly IArizaKategoriService _arizaKategoriService;
        public ArizaKategorisController(IArizaKategoriService arizaKategoriService)
        {
            _arizaKategoriService = arizaKategoriService;
        }

        #region Index Operation
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AjaxIndex()
        {
            return View(_arizaKategoriService.GetAll().ToList());
        }
        #endregion

        #region Details Operations
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArizaKategori arizaKategori = _arizaKategoriService.GetById(id);
            if (arizaKategori == null)
            {
                return HttpNotFound();
            }
            return View(arizaKategori);
        }

        [FormCevapAspect]
        public JsonResult DetailsAjax(Guid id)
        {
            ArizaKategori arizaKategori = _arizaKategoriService.GetById(id);
            if (arizaKategori == null)
                return Json(HttpNotFound().StatusDescription);
            return Json(arizaKategori);
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
        public JsonResult Create([Bind(Include = "Id,Adi,UstArizaKategoriId,Aciklama")] ArizaKategori arizaKategori)
        {
            arizaKategori.Id = Guid.NewGuid();
            _arizaKategoriService.Add(arizaKategori);
            return Json(null);
        }

        #endregion

        #region Edit Operation
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArizaKategori arizaKategori = _arizaKategoriService.GetById(id);
            if (arizaKategori == null)
            {
                return HttpNotFound();
            }
            return View(arizaKategori);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormCevapAspect]
        public JsonResult Edit([Bind(Include = "Id,Adi,UstArizaKategoriId,Aciklama")] ArizaKategori arizaKategori)
        {
            _arizaKategoriService.Update(arizaKategori);
            return Json(null);
        }
        #endregion

        #region Delete Operatin
        public ActionResult Delete(Guid id)
        {
            
            ArizaKategori arizaKategori = _arizaKategoriService.GetById(id);
            if (arizaKategori == null)
            {
                return HttpNotFound();
            }
            return View(arizaKategori);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [FormCevapAspect]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _arizaKategoriService.Delete(_arizaKategoriService.GetById(id));
            return Json(null);
        }
        #endregion
    }
}