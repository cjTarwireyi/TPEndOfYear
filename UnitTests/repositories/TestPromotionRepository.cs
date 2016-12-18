using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.factories;
using BusineesLogic.repositories;
using BusineesLogic.domain;
using BusineesLogic.repositories.Impl;
namespace UnitTests.repositories
{
    [TestClass]
    public class TestPromotionRepository
    {
        [TestMethod]
        public void TestPromotionRepo()
        {
            //CREATE TEST
            DateTime date = DateTime.Parse("1/1/1900 12:00:00 AM");
            PromotionRepositoryImpl repo = new PromotionRepositoryImpl();
            PromotionDetailsDTO createDetails = PromotionDetailsFactory.createPromotionDetails(5, DateTime.Parse("1/2/2016 12:00:00 PM"), DateTime.Parse("1/2/2016 12:00:00 PM"));
            PromotionDTO createDto = PromotionFactory.createPromotion(1, createDetails, DateTime.Now);
            bool added = repo.add(createDto);
            Assert.IsTrue(added);

            //TEST FIND LAST RECORD
            PromotionDTO timesheet = repo.getLastReocrd();
            Assert.IsNotNull(timesheet);

            //TESTUPDATE
            PromotionDTO updatePromotion = new PromotionDTO.PromotionBuilder()
            .copy(timesheet)
            .buildDateCreated(DateTime.Parse("1/1/2017 09:00:00 AM"))
            .build();
            repo.updatePromotion(updatePromotion);
            Assert.AreEqual(DateTime.Parse("1/1/2017 09:00:00 AM"), repo.getLastReocrd().dateCreated);

            //TEST DELETE
            bool deleted = repo.deletePromotion(repo.getLastReocrd().id);
            Assert.IsTrue(deleted);

        }
    }
}
