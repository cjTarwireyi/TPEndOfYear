using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.factories.supplier
{
    [TestClass]
    public class TestSupplier
    {
        [TestMethod]
        public void createSupplier()
        {
            SupplierDTO supplier = new SupplierDTO.SupplierBuilder()
            .supName("Shireen")
            .supSurname("Wilkinson")
            .supCellNumber("0783588370")
            .supAddress("Sparrow","Rocklands","7798")
            .build();

            Assert.AreEqual(supplier.supplierName, "Shireen");
            Assert.AreEqual(supplier.supplierSurname, "Wilkinson");
            Assert.AreEqual(supplier.supplierStreetName, "Sparrow");
        }
    }
}
