using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TmTFramework.Business.Abstract;
using TmTFramework.Core.Aspects.Postsharp.MvcWebUiAspects;
using TmTFramework.Entities.Concrete;
using TmTFramework.MvcWebUI.Models;

namespace TmTFramework.MvcWebUI.Controllers
{
    public class AracKabulController : Controller
    {
        private readonly IServisService _servisService;
        private readonly IArizaKategoriService _arizaKategoriService;
        private readonly IPersonelService _personelService;
        private readonly IAracService _aracService;
        private readonly IAracArizaKayitService _aracArizaKayitService;
        private readonly IAracBakimService _aracBakimService;


        public AracKabulController(IServisService servisService, IArizaKategoriService arizaKategoriService, IPersonelService personelService, IAracService aracService, IAracArizaKayitService aracArizaKayitService, IAracBakimService aracBakimService)
        {
            _servisService = servisService;
            _arizaKategoriService = arizaKategoriService;
            _personelService = personelService;
            _aracService = aracService;
            _aracArizaKayitService = aracArizaKayitService;
            _aracBakimService = aracBakimService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AracKayit()
        {
                ViewBag.ArizaKategoriId = new SelectList(_arizaKategoriService.GetAll().Select(h => new { Id = h.Id, Text = h.Adi }).ToList(), "Id", "Text");
                ViewBag.SorumluPersonelId = new SelectList(_personelService.GetAll().Select(h => new { Id = h.Id, Text = h.AdSoyad + " - " + h.Unvan }).ToList(), "Id", "Text");
                ViewBag.AracId = new SelectList(_aracService.GetAll().Select(h => new { Id = h.Id, Plaka = h.Plaka }).ToList(), "Id", "Plaka");
                return View();
        }


        [HttpPost]
        [ActionName("AracKayit")]
        [FormCevapAspect]
        public JsonResult AracKayitPost(FormCollection fc)
        {

            Servis servis = new Servis();
            servis.AracId = Guid.Parse(fc["aracId"]);
            servis.ServisZamani = DateTime.Now;
            servis.Id = Guid.NewGuid();

            List<AracArizaKayit> arizalar = new List<AracArizaKayit>();
            AracArizaKayit k;
            foreach (var index in fc["arizaIndex"].Split(','))
            {
                k = new AracArizaKayit();

                k.Id = Guid.NewGuid();
                k.KayitZamani = DateTime.Now;

                if (string.IsNullOrEmpty(fc["SorumluPersonelId" + index]))
                {
                    k.PersonelId = null;
                }
                else
                {
                    k.PersonelId = Guid.Parse(fc["SorumluPersonelId" + index]);
                }
                k.ArizaKategoriId = Guid.Parse(fc["ArizaKategoriId" + index]);
                k.TahminiSure = int.Parse(fc["tahminiSure" + index]);
                k.Aciklama = fc["arizaKayitAciklama" + index];

                k.ServisId = servis.Id;
                arizalar.Add(k);
            }
            _aracBakimService.AddServisAndArizaKayit(servis, arizalar);
            return Json(null);
        }

        [FormCevapAspect]
        public JsonResult AracKayitBilgi(Guid id)
        {
                return Json(_aracService.GetCarInfoForAd(id));
        }
    }
}