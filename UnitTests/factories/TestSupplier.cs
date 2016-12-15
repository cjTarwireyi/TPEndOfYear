using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BusineesLogic.factories;

namespace UnitTests.factories.supplier
{
    [TestClass]
    public class TestSupplier
    {
        [TestMethod]
        public void testCreateSupplier()
        {
            List<string> supplierDetails = new List<string>();
            supplierDetails.Add("Shireen");
            supplierDetails.Add("Wilkinson");
            supplierDetails.Add("0783588370");
            supplierDetails.Add("Sparrow");
            supplierDetails.Add("Rocklands");
            supplierDetails.Add("7798");
            

            SupplierDTO supplier = SupplierFactory.createSupplier(supplierDetails);

            Assert.AreEqual(supplier.supplierName, "Shireen");
            Assert.AreEqual(supplier.supplierSurname, "Wilkinson");
            Assert.AreEqual(supplier.supplierStreetName, "Sparrow");
        }

        [TestMethod]
        public void testUpdateSupplier()
        {
            List<string> supplierDetails = new List<string>();
            supplierDetails.Add("Shireen");
            supplierDetails.Add("Wilkinson");
            supplierDetails.Add("0783588370");
            supplierDetails.Add("Sparrow");
            supplierDetails.Add("Rocklands");
            supplierDetails.Add("7798");


            SupplierDTO supplier = SupplierFactory.createSupplier(supplierDetails);
            SupplierDTO updateSupplier = new SupplierDTO.SupplierBuilder()
               .copy(supplier)
               .supName("Siraaj")
               .build();

            Assert.AreNotEqual(supplier.supplierName, updateSupplier.supplierName);
            
           
        }
    }
}
