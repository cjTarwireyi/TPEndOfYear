using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.repositories.Impl;
using System.Collections.Generic;
using BusineesLogic.factories;

namespace UnitTests.repositories
{
    [TestClass]
    public class TestSupplierRepository
    {
        private SupplierDTO result;
        private SupplierRepositoryImpl repo = new SupplierRepositoryImpl();

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
            repo.save(supplier);
            result = repo.getLastReocrd();
            int id = result.supplierNumber;
            Assert.IsNotNull(result);


            //update
            SupplierDTO updateSupplier = new SupplierDTO.SupplierBuilder()
                                                        .copy(result)
                                                        .supName("Siraaj")
                                                        .build();
            repo.update(updateSupplier);
            result = repo.findByID(id);


            //delete
            repo.delete(id);
            result = repo.findByID(id);
            Assert.IsNull(result);
        }
    }
}
