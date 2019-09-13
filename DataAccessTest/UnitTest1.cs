using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TmTFramework.Core.DataAccess.Dapper;
using TmTFramework.DataAccess.Concrete.Dapper;
using TmTFramework.Entities.Concrete;

namespace DataAccessTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            #region Dapper Framework Test

            DapperMusteriDal db = new DapperMusteriDal(new DapperHelper<Musteri>());
            //Complex Type Test
            var k = db.GetMusteriIndexList();

            //Insert Test
            db.Add(new Musteri()
            {
                Id = Guid.NewGuid(),
                Adres = "Düzce",
                AdSoyad = "Selman",
                Email = "selamn@selamn.com",
                Telefon = "456789123",
                VergiDairesi = "Hamiidiye",
                VergiNo = "741258"
            }); 
            

            #endregion
        }
    }
}
