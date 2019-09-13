using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Ninject.Parameters;
using TmTFramework.Business.Abstract;
using TmTFramework.Core.Aspects.Postsharp.MvcWebUiAspects;
using TmTFramework.Entities.Concrete;
using TmTFramework.MvcWebUI.Filters;


namespace TmTFramework.MvcWebUI.Controllers
{
    public class ServisKayitController : Controller
    {

        private readonly IServisService _servisService;
        private readonly IAracService _aracService;
        private readonly IAracBakimService _aracBakimService;
        private readonly IAracArizaKayitService _aracArizaKayitService;


        public ServisKayitController(IServisService servisService, IAracService aracService, IAracBakimService aracBakimService, IAracArizaKayitService aracArizaKayitService)
        {
            _servisService = servisService;
            _aracService = aracService;
            _aracBakimService = aracBakimService;
            _aracArizaKayitService = aracArizaKayitService;
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AjaxIndex()
        {
            return View(_servisService.GetServisDetails());
        }

      
        [CheckParameterFilter]
        public ActionResult Details(Guid? id)
        {
            if(id==null)
                throw  new Exception();
            var servis = _servisService.GetServisDetailsById((Guid)id);
            if (servis == null)
                throw new Exception(HttpNotFound().StatusCode.ToString());
            return View(servis); 
        }

        
        public ActionResult Create()
        {
            ViewBag.AracId = new SelectList(_aracService.GetAll(), "Id", "Plaka");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ServisZamani,AracId")] Servis servis)
        { 
            servis.Id = Guid.NewGuid();
            _servisService.Add(servis);
            return Json(null);
        }

        [CheckParameterFilter]
        public ActionResult Edit(Guid? id)
        {
            Servis servis = _servisService.GetById((Guid)id);
            if (servis == null)
                return HttpNotFound();
            
            ViewBag.AracId = new SelectList(_aracService.GetAll(), "Id", "Plaka", servis.AracId);
            return View(servis);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ServisZamani,AracId")] Servis servis)
        {
            _servisService.Update(servis);
            return Json(null);
        }


        [CheckParameterFilter]
        public ActionResult Delete(Guid? id)
        {
            Servis servis = _servisService.GetById((Guid)id);
            if (servis == null)
                return HttpNotFound();
            
            return View(servis);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [FormCevapAspect]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _aracBakimService.DeleteServiceWithVehicleFailures(id);
            //_aracBakimService.DeleteServiceWithVehicleFailures(_servisService.GetById(id),_aracArizaKayitService.GetListByServisId(id));
            return Json(null);
        }

        
    }
}
