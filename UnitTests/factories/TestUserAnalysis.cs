using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.factories;
using BusineesLogic.domain;
namespace UnitTests.domain
{
    [TestClass]
    public class TestUserAnalysis
    {
        [TestMethod]
        public void TestUserAnalyaisDTO()
        {
            //CREATE TEST
            DateTime date = DateTime.Parse("1/1/1900 12:00:00 AM");

            UserAnalysisDTO userAnalysis = UserAnalysisFactory.createAnalysis(1,"Users",1, date);
            Assert.AreEqual(DateTime.Parse("1/1/1900 12:00:00 AM"), userAnalysis.dateModified);
            Assert.AreEqual(1, userAnalysis.userId);
            Assert.AreEqual("Users", userAnalysis.pageAccessed);

            //TEST UPDATE
            UserAnalysisDTO update = new UserAnalysisDTO.UserAnalysisBuilder()
                .copy(userAnalysis)
                .buildUserId(5)
                .build();
            Assert.AreEqual(5, update.userId);
            Assert.AreEqual(update.pageAccessed, userAnalysis.pageAccessed);
            Assert.AreEqual(update.dateModified, userAnalysis.dateModified);

        }
    }
}
