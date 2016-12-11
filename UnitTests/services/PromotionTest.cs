using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.Interface;
using BusineesLogic.factories;
using BusineesLogic.services;
using BusineesLogic.domain;

namespace UnitTests.services
{
    [TestClass]
    public class PromotionTest
    {
        [TestMethod]
        public void PromotionCrudTest()
        {
            //CREATE TEST
            DateTime date = DateTime.Parse("1/1/1900 12:00:00 AM");
            IPromotion service = new PromotionDAO();
            PromotionDetailsDTO createDetails = PromotionDetailsFactory.createPromotionDetails(5, DateTime.Parse("1/2/2016 12:00:00 PM"), DateTime.Parse("1/2/2016 12:00:00 PM"));
            PromotionDTO createDto = PromotionFactory.createPromotion(1, createDetails, DateTime.Now);
            bool added = service.add(createDto);
            Assert.IsTrue(added);
        }
    }
}
