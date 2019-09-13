using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TmTFramework.Business.Abstract;
using TmTFramework.Entities.Concrete;

namespace TmTFramework.WebApi.Controllers
{
    public class MusteriController : ApiController
    {
        private IMusteriService _musteriService;

        public MusteriController(IMusteriService musteriService)
        {
            _musteriService = musteriService;
        }


        public List<Musteri> Get()
        {
            return _musteriService.GetAll().Take(1).ToList();
        }
    }
}
