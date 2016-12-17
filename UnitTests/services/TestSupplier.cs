using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BusineesLogic.factories;

namespace UnitTests.services
{
    [TestClass]
    public class TestSupplier
    {
        private SupplierDTO result;
        private SupplierDAO service = new SupplierDAO();
        [TestMethod]
        public void testInsertUpdateDeleteSupplier()
        {
            List<string> supplierDetails = new List<string>();
            supplierDetails.Add("Shireen");
            supplierDetails.Add("Wilkinson");
            supplierDetails.Add("0783588370");
            supplierDetails.Add("Sparrow");
            supplierDetails.Add("Rocklands");
            supplierDetails.Add("7798");
            SupplierDTO supplier = SupplierFactory.createSupplier(supplierDetails);

            //insert
            service.save(supplier);
            result = service.getLastReocrd();
            int id = result.supplierNumber;
            Assert.IsNotNull(result);


            //update
            SupplierDTO updateSupplier = new SupplierDTO.SupplierBuilder()
                                                        .copy(result)
                                                        .supName("Siraaj")
                                                        .build();
            service.updateSupplier(updateSupplier);
            result = service.getSupplier(id);


            //delete
            service.delete(id.ToString());
            result = service.getSupplier(id);
            Assert.IsNull(result);

        }
    }
}