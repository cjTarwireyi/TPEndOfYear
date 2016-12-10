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
            //CREATE TEST
            TimeSheetDTO timesheetDto = TimeSheetFactory.createTimeSheet(14, 5, 12);
            Assert.AreEqual(14, timesheetDto.day);
            Assert.AreEqual(5, timesheetDto.hour);
            Assert.AreEqual(12, timesheetDto.minutes);

            //UPDATE TEST
            TimeSheetDTO update = new TimeSheetDTO.TimeSheetBuilder()
                .copy(timesheetDto)
                .buildDay(14)
                .build();
            Assert.AreEqual(14, update.day);
            Assert.AreEqual(timesheetDto.hour, timesheetDto.hour);
            Assert.AreEqual(timesheetDto.minutes, timesheetDto.minutes);

        }
    }
}
