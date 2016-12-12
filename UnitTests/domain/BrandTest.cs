using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.factories;
using BusineesLogic.domain;

namespace UnitTests.domain
{
    [TestClass]
    public class BrandTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //CREATE
            BrandDTO createBrand = BrandFactory.createBrand("test", "test", DateTime.Parse("1/1/1900 12:00:00 AM"),true);
            Assert.AreEqual("test", createBrand.brandName);
            Assert.AreEqual("test", createBrand.brandDescription);
            Assert.AreEqual(DateTime.Parse("1/1/1900 12:00:00 AM"), createBrand.dateCreated);
            Assert.AreEqual(true, createBrand.active);
        }
    }
}
