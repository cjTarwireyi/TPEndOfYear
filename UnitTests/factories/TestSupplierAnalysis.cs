using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.factories;
using BusineesLogic.domain;

namespace UnitTests.domain
{
    [TestClass]
    public class TestSupplierAnalysis
    {
        [TestMethod]
        public void TestSupplierAnalysisDTO()
        {
            //CREATE TEST
            DateTime date = DateTime.Parse("1/1/1900 12:00:00 AM");

            SuplierAnalysisDTO supplierAnalysis = SupplierAnalysisFactory.create(1,4, "low supply", date);
            Assert.AreEqual(DateTime.Parse("1/1/1900 12:00:00 AM"), supplierAnalysis.dateModified);
            Assert.AreEqual(4, supplierAnalysis.productId);
            Assert.AreEqual("low supply", supplierAnalysis.description);

            //TEST UPDATE
            SuplierAnalysisDTO update = new SuplierAnalysisDTO.SupplierAnalysisBuilder()
                .copy(supplierAnalysis)
                .buildProductId(5)
                .build();
            Assert.AreEqual(5, update.productId);
            Assert.AreEqual(update.description, supplierAnalysis.description);
            Assert.AreEqual(update.dateModified, supplierAnalysis.dateModified);
        }
    }
}
