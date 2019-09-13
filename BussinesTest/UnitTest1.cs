using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TmTFramework.Business.Abstract;
using TmTFramework.Business.Concrete.Managers;
using TmTFramework.DataAccess.Abstract;
using TmTFramework.DataAccess.Concrete.Dapper;
using TmTFramework.Entities.Concrete;

namespace BussinesTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            MusteriManager _musteriService = new MusteriManager( new DapperMusteriDal( new TmTFramework.Core.DataAccess.Dapper.DapperHelper<Musteri>()) );

            var k = _musteriService.GetList();
            var m = _musteriService.GetList(x => x.Adres == "Düzce" || x.Adres == "İstanbul");
            var teset2 = _musteriService.GetList(x => (x.AdSoyad == "Selman" || x.Adres == "Düzce") && (x.Telefon == "456789123" && x.VergiNo == "741258"));

        }
    }
}
