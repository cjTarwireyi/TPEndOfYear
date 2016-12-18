using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.Interface;
using BusineesLogic.factories;
using BusineesLogic.services;
using BusineesLogic.domain;

namespace UnitTests.services
{
    [TestClass]
    public class TestPromotionService
    {
        [TestMethod]
        public void TestPromotionServiceMethods()
        {
            //CREATE TEST
            DateTime date = DateTime.Parse("1/1/1900 12:00:00 AM");
            IPromotion service = new PromotionDAO();
            PromotionDetailsDTO createDetails = PromotionDetailsFactory.createPromotionDetails(5, DateTime.Parse("1/2/2016 12:00:00 PM"), DateTime.Parse("1/2/2016 12:00:00 PM"));
            PromotionDTO createDto = PromotionFactory.createPromotion(1, createDetails, DateTime.Now);
            bool added = service.add(createDto);
            Assert.IsTrue(added);

            //TEST FIND LAST RECORD
            PromotionDTO timesheet = service.getLastReocrd();
            Assert.IsNotNull(timesheet);

            //TESTUPDATE
            PromotionDTO updatePromotion = new PromotionDTO.PromotionBuilder()
            .copy(timesheet)
            .buildDateCreated(DateTime.Parse("1/1/2017 09:00:00 AM"))
            .build();
            service.Update(updatePromotion);
            Assert.AreEqual(DateTime.Parse("1/1/2017 09:00:00 AM"), service.getLastReocrd().dateCreated);

            //TEST DELETE
            bool deleted = service.Delete(service.getLastReocrd().id);
            Assert.IsTrue(deleted);

        }
    }
}
