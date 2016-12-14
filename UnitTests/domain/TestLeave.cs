using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.factories;
using BusineesLogic.domain;
namespace UnitTests.domain
{
    [TestClass]
    public class TestLeave
    {
        [TestMethod]
        public void TestDTO()
        {
            //CREATE TEST
            DateTime date = DateTime.Parse("1/1/1900 12:00:00 AM");

            LeaveDTO leaveDto =LeaveFactory.createLeave("Sick Leave", "sick", date);
            Assert.AreEqual(DateTime.Parse("1/1/1900 12:00:00 AM"), leaveDto.dateModified);
            Assert.AreEqual("Sick Leave", leaveDto.leaveTitle);
            Assert.AreEqual("sick", leaveDto.description);
 

        }
    }
}
