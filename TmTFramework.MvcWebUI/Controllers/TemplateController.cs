

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

namespace $rootnamespace$
{
    public class $safeitemname$Controller : Controller
    {

        private I$safeitemname$Service _$safeitemname$Service;
        private IMusteriService _musteriService;
        public $safeitemname$sController(I$safeitemname$Service $safeitemname$Service)
        {
            _$safeitemname$Service = $safeitemname$Service;
            
        }
        #region Index Operation
        // GET: Musteri
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult AjaxIndex()
        {
            return View(_$safeitemname$Service.GetAllWithDetail());
        }
        #endregion

        #region Details Operations
        [CheckParameterFilter]
        public ActionResult Details(Guid id)
        {
            $safeitemname$ $safeitemname$ = _$safeitemname$Service.GetById(id);
            if ($safeitemname$ == null)
            {
                return HttpNotFound();
            }
            return View($safeitemname$);
        }

        [FormCevapAspect]
        public JsonResult DetailsAjax(Guid id)
        {
            $safeitemname$ $safeitemname$ = _$safeitemname$Service.GetById(id);
            if ($safeitemname$ == null)
                return Json(HttpNotFound().StatusDescription);
            return Json($safeitemname$);
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
        public JsonResult Create($safeitemname$ $safeitemname$)
        {

            $safeitemname$.Id = Guid.NewGuid();
            _$safeitemname$Service.Add($safeitemname$);
            return Json(null);
        }

        #endregion

        #region Edit Operation
        [CheckParameterFilter]
        public ActionResult Edit(Guid id)
        {
            $safeitemname$ $safeitemname$ = _$safeitemname$Service.GetById(id);
            if ($safeitemname$ == null)
                return HttpNotFound();
           
            return View($safeitemname$);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormCevapAspect]
        public JsonResult Edit($safeitemname$ $safeitemname$)
        {
            _$safeitemname$Service.Update($safeitemname$);
            return Json(null);
        }
        #endregion

        #region Delete Operatin
        [CheckParameterFilter]
        public ActionResult Delete(Guid id)
        {

            $safeitemname$ $safeitemname$ = _$safeitemname$Service.GetById(id);
            if ($safeitemname$ == null)
            {
                return HttpNotFound();
            }
            return View($safeitemname$);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [FormCevapAspect]
        [CheckParameterFilter]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _$safeitemname$Service.Delete(_$safeitemname$Service.GetById(id));
            return Json(null);
        }
        #endregion
    }
}
