using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.factories;
using BusineesLogic.repositories;
using BusineesLogic.domain;
using BusineesLogic.repositories.Impl;

namespace UnitTests.repositories
{
    [TestClass]
    public class TestUserAnalysisRepository
    {
        [TestMethod]
        public void TestUserAnalysisRepo()
        {
            UserAnalysisRepository repo = new UserAnalysisRepository();
            //CREATE TEST
            DateTime date = DateTime.Parse("1/1/1900 12:00:00 AM");

            UserAnalysisDTO userAnalysis = UserAnalysisFactory.createAnalysis(1, "Users", 1, date);
            repo.save(userAnalysis);
            
            //Assert.AreEqual(DateTime.Now, repo.getLastReocrd().dateModified);
            Assert.AreEqual(1, repo.getLastReocrd().userId);
            Assert.AreEqual("Users", repo.getLastReocrd().pageAccessed.Trim());
            Assert.AreEqual(1, repo.getLastReocrd().timesAccessed);

            //TEST UPDATE
            UserAnalysisDTO found = repo.getLastReocrd();
            UserAnalysisDTO update = new UserAnalysisDTO.UserAnalysisBuilder()
                .copy(found)
                .buildTimesAccessed(5)
                .build();
            repo.update(update);
            Assert.AreEqual(5, repo.getLastReocrd().timesAccessed);
            Assert.AreEqual(update.pageAccessed, repo.getLastReocrd().pageAccessed);
            Assert.AreEqual(update.dateModified, repo.getLastReocrd().dateModified);

            repo.delete(found.id);
            Assert.IsNull(repo.findByID(found.id));
            
        }
    }
}
