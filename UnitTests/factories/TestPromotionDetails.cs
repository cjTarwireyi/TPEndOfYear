using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.domain;
using BusineesLogic.factories;

namespace UnitTests.factories
{
    [TestClass]
    public class TestPromotionDetails
    {
        [TestMethod]
        public void testCreatePromotionDetails()
        {
            
            PromotionDetailsDTO promotion = PromotionDetailsFactory.createPromotionDetails((decimal)200,DateTime.Now,DateTime.Now.AddDays(10));
            Assert.IsNotNull(promotion);
        }


        [TestMethod]
        public void testUpdatePromtion()
        {

            PromotionDetailsDTO promotion = PromotionDetailsFactory.createPromotionDetails((decimal)200, DateTime.Now, DateTime.Now.AddDays(10));
            PromotionDetailsDTO updatePromo = new PromotionDetailsDTO.PromotionDetailsBuilder()
                                                                        .copy(promotion)
                                                                        .buildEndDate(DateTime.Now.AddDays(-5))
                                                                        .build();
            Assert.AreNotEqual(promotion.endDate,updatePromo.endDate);
            Assert.IsNotNull(promotion);
        }
    }
}
