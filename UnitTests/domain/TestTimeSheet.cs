using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.factories;
using BusineesLogic.domain;

namespace UnitTests.domain
{
    [TestClass]
    public class TestTimeSheet
    {
        [TestMethod]
        public void TestTimeSheetDTO()
        {
            TimeSheetDTO timesheetDto = TimeSheetFactory.createTimeSheet(14, 5, 12);
            Assert.AreEqual(14, timesheetDto.day);
            Assert.AreEqual(5, timesheetDto.hour);
            Assert.AreEqual(12, timesheetDto.minutes);
        }
    }
}
