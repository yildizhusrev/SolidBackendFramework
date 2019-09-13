using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TmTFramework.Business.Abstract;
using TmTFramework.Entities.Concrete;
using TmTFramework.MvcWebUI.Models;

namespace TmTFramework.MvcWebUI.Controllers
{
    public class MusterisController : Controller
    {
        private readonly IMusteriService _musteriService;
        private readonly IAracService _aracService;
        public MusterisController(
            IMusteriService MusteriService,
            IAracService aracService
            )
        {
            _musteriService = MusteriService;
            _aracService = aracService;
        }
        // GET: Musteri
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AjaxIndex()
        {    
            
            return View(_musteriService.GetMusteriIndexList());
        }
        // GET: Musteris/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musteri musteri = _musteriService.GetById(id);
            if (musteri == null)
            {
                return HttpNotFound();
            }
            return View(musteri);
        }

        // GET: Musteris/Create
        public ActionResult Create()
        {

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create([Bind(Include = "Id,AdSoyad,Telefon,Adres,VergiDairesi,VergiNo,Email")] Musteri musteri)
        {
            AjaxCevap cevap = new AjaxCevap();
            if (ModelState.IsValid)
            {
                musteri.Id = Guid.NewGuid();
                _musteriService.Add(musteri);
               
                cevap.data = Url.Action("Index");
                cevap.sonuc = true;
                cevap.mesaj = "Müşteri kaydedildi";
                return Json(cevap, JsonRequestBehavior.AllowGet);
            }
            cevap.data = null;
            cevap.mesaj = "Müşteri bilgilerini kontrol Ediniz";
            cevap.sonuc = false;
            return Json(cevap, JsonRequestBehavior.AllowGet);

        }

        // GET: Musteris/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musteri musteri = _musteriService.GetById(id);
            if (musteri == null)
            {
                return HttpNotFound();
            }
            return View(musteri);
        }

        // POST: Musteris/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AdSoyad,Telefon,Adres,VergiDairesi,VergiNo,Email")] Musteri musteri)
        {
            AjaxCevap cevap = new AjaxCevap();
            if (ModelState.IsValid)
            {
                _musteriService.Update(musteri);
              
                cevap.data = Url.Action("Index");
                cevap.sonuc = true;
                cevap.mesaj = "Müşteri kaydedildi";
                return Json(cevap, JsonRequestBehavior.AllowGet);
            }
            cevap.data = null;
            cevap.mesaj = "Müşteri bilgilerini kontrol Ediniz";
            cevap.sonuc = false;
            return Json(cevap, JsonRequestBehavior.AllowGet);
        }

        // GET: Musteris/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musteri musteri = _musteriService.GetById(id);
            if (musteri == null)
            {
                return HttpNotFound();
            }
            return View(musteri);
        }

        // POST: Musteris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(Guid id)
        {
            Musteri musteri = _musteriService.GetById(id);
            if (_aracService.GetAll().Count(h=>h.MusteriId==id) > 0)
                return Json(new AjaxCevap { data = null, mesaj = "Müşterinin kayıtlı aracları var. Silme işlemi için önce araçları silmelisiniz", sonuc = false }, JsonRequestBehavior.AllowGet);
            _musteriService.Delete(musteri);
            
            return Json(new AjaxCevap { data = Url.Action("Index"), mesaj = "Müşteri silme işlemi gerçekleştirildi.", sonuc = true }, JsonRequestBehavior.AllowGet);
        }
    }
}