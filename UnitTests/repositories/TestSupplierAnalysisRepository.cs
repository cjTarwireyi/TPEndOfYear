using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.domain;
using BusineesLogic.factories;
using BusineesLogic.repositories.Impl;

namespace UnitTests.repositories
{
    [TestClass]
    public class TestSupplierAnalysisRepository
    {
        [TestMethod]
        public void TestSupplierAnalysisRepo()
        {
            SupplierAnalysisRepository repo = new SupplierAnalysisRepository();
            //CREATE TEST
            DateTime date = DateTime.Parse("1/1/1900 12:00:00 AM");

            SuplierAnalysisDTO supplierAnalysis = SupplierAnalysisFactory.create(1, 4, "low supply", date);
            Assert.AreEqual(DateTime.Parse("1/1/1900 12:00:00 AM"), supplierAnalysis.dateModified);
            Assert.AreEqual(4, supplierAnalysis.productId);
            Assert.AreEqual("low supply", supplierAnalysis.description);
            repo.save(supplierAnalysis);
            SuplierAnalysisDTO found = repo.getLastReocrd();
            //TEST UPDATE
            SuplierAnalysisDTO update = new SuplierAnalysisDTO.SupplierAnalysisBuilder()
                .copy(found)
                .buildProductId(5)
                .build();
            repo.update(update);
            Assert.AreEqual(5, repo.getLastReocrd().productId);
            Assert.AreEqual(update.description, repo.getLastReocrd().description);
            Assert.AreEqual(update.dateModified, repo.getLastReocrd().dateModified);

            //TEST DELETE
            repo.delete(found.id);
            Assert.IsNull(repo.findByID(found.id));
        }
    }
}
