using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BusineesLogic.domain;
using BusineesLogic.factories;

namespace UnitTests.factories
{
    [TestClass]
    public class TestSale
    {
        [TestMethod]
        public void testCreateSale()
        {
            List<int> salesDetails = new List<int>();
            salesDetails.Add(1);
            salesDetails.Add(200);
            salesDetails.Add(120);

            SaleDTO sale = SaleFactory.createSale(salesDetails);
            Assert.AreEqual(sale.originalPrice,(decimal)200);
        }


        [TestMethod]
        public void testUpdateSale()
        {
            List<int> salesDetails = new List<int>();
            salesDetails.Add(1);
            salesDetails.Add(200);
            salesDetails.Add(120);

            SaleDTO sale = SaleFactory.createSale(salesDetails);
            SaleDTO updateSale = new SaleDTO.SaleBuilder()
                                    .copy(sale)
                                     .buildOriginalPrice((decimal)300)
                                     .build();


            Assert.AreNotEqual(sale.originalPrice, updateSale.originalPrice);
        }
    }
}
