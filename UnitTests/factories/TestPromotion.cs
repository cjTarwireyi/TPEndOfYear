using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.factories;
using BusineesLogic.domain;

namespace UnitTests.domain
{
    [TestClass]
    public class TestPromotion
    {
        [TestMethod]
        public void TestCreatePromotion()
        {
            //CREATION
            PromotionDetailsDTO createDetails = PromotionDetailsFactory.createPromotionDetails(5, DateTime.Parse("1/2/2016 12:00:00 PM"), DateTime.Parse("1/2/2016 12:00:00 PM"));
            PromotionDTO createDto = PromotionFactory.createPromotion(1, createDetails, DateTime.Now);
            Assert.AreEqual(1, createDto.productId);
            Assert.AreEqual(DateTime.Parse("1/2/2016 12:00:00 PM"), createDto.promotionDetails.endDate);
            Assert.AreEqual(5, createDto.promotionDetails.discountPercent);

            //UPDATE
            PromotionDTO updatePromotion = new PromotionDTO.PromotionBuilder()
            .copy(createDto)
            .BuildProductId(2)
            .build();
            Assert.AreEqual(2, updatePromotion.productId);
            Assert.AreEqual(DateTime.Parse("1/2/2016 12:00:00 PM"), updatePromotion.promotionDetails.endDate);
            Assert.AreEqual(5, createDto.promotionDetails.discountPercent);

        }
    }
}
