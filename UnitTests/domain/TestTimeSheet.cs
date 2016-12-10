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
            DateTime date = DateTime.Parse("1/1/1900 12:00:00 AM");

            TimeSheetDTO timesheetDto = TimeSheetFactory.createTimeSheet(date, 5, 12);
            Assert.AreEqual(DateTime.Parse("1/1/1900 12:00:00 AM"), timesheetDto.date);
            Assert.AreEqual(5, timesheetDto.hourIn);
            Assert.AreEqual(12, timesheetDto.hourOut);

            //UPDATE TEST
            TimeSheetDTO update = new TimeSheetDTO.TimeSheetBuilder()
                .copy(timesheetDto)
                .buildHourIn(14)
                .build();
            Assert.AreEqual(14, update.hourIn);
            Assert.AreEqual(update.date, timesheetDto.date);
            Assert.AreEqual(update.hourOut, timesheetDto.hourOut);

        }
    }
}
