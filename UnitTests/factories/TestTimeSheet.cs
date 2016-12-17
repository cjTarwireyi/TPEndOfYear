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

            TimeSheetDTO timesheetDto= TimeSheetFactory.createTimeSheet(1,date, "10:00", "17:00","comments");
            Assert.AreEqual(DateTime.Parse("1/1/1900 12:00:00 AM"), timesheetDto.date);
            Assert.AreEqual("10:00", timesheetDto.timeIn);
            Assert.AreEqual("17:00", timesheetDto.timeOut);
            Assert.AreEqual(1, timesheetDto.employeeId);
            Assert.AreEqual("comments", timesheetDto.comments);

            //UPDATE TEST
            TimeSheetDTO update = new TimeSheetDTO.TimeSheetBuilder()
                .copy(timesheetDto)
                .buildTimeIn("10:30")
                .build();
            Assert.AreEqual("10:30", update.timeIn);
            Assert.AreEqual(update.date, timesheetDto.date);
            Assert.AreEqual(update.timeOut, timesheetDto.timeOut);
            Assert.AreEqual(update.employeeId, timesheetDto.employeeId);

        }
    }
}
