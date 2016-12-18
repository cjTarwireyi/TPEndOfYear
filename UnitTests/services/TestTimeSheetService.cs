using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.Interface;
using BusineesLogic.factories;
using BusineesLogic.services;
using BusineesLogic.domain;

namespace UnitTests.services
{
    [TestClass]
    public class TestTimeSheetService
    {
        [TestMethod]
        public void TestTimeSheetServiceMethods()
        {
            //CREATE TEST
            DateTime date = DateTime.Parse("1/1/1900 12:00:00 AM");
            ITimeSheet service = new TimeSheetDAO();
            //CREATE TEST


            TimeSheetDTO addTimeSheet = TimeSheetFactory.createTimeSheet(1, date, "10:00", "17:00", "comments");
            bool added = service.addTimeSheet(addTimeSheet);
            Assert.IsTrue(added);
            //TEST FIND LAST RECORD
            TimeSheetDTO timesheet = service.getLastReocrd();
            Assert.IsNotNull(timesheet);

            //TEST UPDATE

            TimeSheetDTO update = new TimeSheetDTO.TimeSheetBuilder()
            .copy(timesheet)
            .buildTimeIn("11:00")
            .build();
            service.UpdateTimeSheet(update);
            Assert.AreEqual("11:00", service.getLastReocrd().timeIn.Trim());

            //TEST DELETE
            bool deleted = service.Delete(service.getLastReocrd().id);
            Assert.IsTrue(deleted);

        }
    }
}
