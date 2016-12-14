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

            UserAnalysisDTO ua = UserAnalysisFactory.createAnalysis(1,"Sold The Most", date);
            Assert.AreEqual(DateTime.Parse("1/1/1900 12:00:00 AM"), ua.dateModified);
            Assert.AreEqual(1, ua.userId);
            Assert.AreEqual("Sold The Most", ua.description);

        }
    }
}
