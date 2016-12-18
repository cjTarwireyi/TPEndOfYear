using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.factories;
using BusineesLogic.repositories;
using BusineesLogic.domain;
using BusineesLogic.services;


namespace UnitTests.services
{
    [TestClass]
    public class TestUserAnalysisService
    {
        [TestMethod]
        public void TestUserAnalysisServiceMethods()
        {
            UserAnalysisDAO service = new UserAnalysisDAO();
            //CREATE TEST
            DateTime date = DateTime.Parse("1/1/1900 12:00:00 AM");

            UserAnalysisDTO userAnalysis = UserAnalysisFactory.createAnalysis(1, "Users", 1, date);
            service.save(userAnalysis);

            //Assert.AreEqual(DateTime.Now, repo.getLastReocrd().dateModified);
            Assert.AreEqual(1, service.getLastReocrd().userId);
            Assert.AreEqual("Users", service.getLastReocrd().pageAccessed.Trim());
            Assert.AreEqual(1, service.getLastReocrd().timesAccessed);

            //TEST UPDATE
            UserAnalysisDTO found = service.getLastReocrd();
            UserAnalysisDTO update = new UserAnalysisDTO.UserAnalysisBuilder()
                .copy(found)
                .buildTimesAccessed(5)
                .build();
            service.update(update);
            Assert.AreEqual(5, service.getLastReocrd().timesAccessed);
            Assert.AreEqual(update.pageAccessed, service.getLastReocrd().pageAccessed);
            Assert.AreEqual(update.dateModified, service.getLastReocrd().dateModified);

            service.delete(found.id);
            Assert.IsNull(service.findByID(found.id));
            
        
        }
    }
}
