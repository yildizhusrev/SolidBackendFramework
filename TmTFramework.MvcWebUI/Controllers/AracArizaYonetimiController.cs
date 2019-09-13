using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TmTFramework.Business.Abstract;
using TmTFramework.Entities.Concrete;
using TmTFramework.MvcWebUI.Models;

namespace TmTFramework.MvcWebUI.Controllers
{
    
    public class AracArizaYonetimiController : Controller
    {
        private readonly IAracArizaKayitService _aracArizaKayitService;
        private readonly IServisService _servisService;
        private readonly IArizaKategoriService _arizaKategoriService;
        private readonly IPersonelService _personelService;

        public AracArizaYonetimiController(
            IPersonelService personelService,
            IAracArizaKayitService aracArizaKayitService,
            IServisService servisService,
            IArizaKategoriService arizaKategoriService
            )
        {
            _aracArizaKayitService = aracArizaKayitService;
            _servisService = servisService;
            _arizaKategoriService = arizaKategoriService;
            _personelService = personelService;
        }
        // GET: AracArizaKayit

        // GET: AracArizaYonetimi
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AjaxIndex()
        {
            return View(_servisService.GetServisDetails());
        }


        public ActionResult ArizaKayitGuncelle(Guid id)
        {
            if (id == Guid.Empty)
                throw new Exception("Parametre yok");
            var aracArizaKayit = _aracArizaKayitService.GetById(id);

            ViewBag.ArizaKategoriId = new SelectList(_arizaKategoriService.GetAll().Select(h => new { Value = h.Id, Text = h.Adi }), "Value", "Text", aracArizaKayit.ArizaKategoriId);
            ViewBag.PersonelId = new SelectList(_personelService.GetAll().Select(h => new { Value = h.Id, Text = h.AdSoyad }), "Value", "Text", aracArizaKayit.PersonelId);

            return View(aracArizaKayit);
        }
        
        [HttpPost]
        [ActionName("ArizaKayitGuncelle")]
        public JsonResult ArizaKayitGuncellePost(AracArizaKayit arac)
        {
            AjaxCevap cevap = new AjaxCevap();
            try
            {
                _aracArizaKayitService.Update(arac);
                cevap.data = arac;
            }
            catch (Exception ex)
            {
                cevap.sonuc = false;
                cevap.mesaj = $"[{ex.Message}] [{ex.InnerException.Message}]";
            }
            return Json(cevap, JsonRequestBehavior.AllowGet);
        }

    }
}