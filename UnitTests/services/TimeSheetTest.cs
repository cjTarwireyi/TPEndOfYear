using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.Interface;
using BusineesLogic.factories;
using BusineesLogic.services;
using BusineesLogic.domain;

namespace UnitTests.services
{
    [TestClass]
    public class TimeSheetTest
    {
        [TestMethod]
        public void TimeSheetCrudTest()
        {
            //CREATE TEST
            DateTime date = DateTime.Parse("1/1/1900 12:00:00 AM");
            ITimeSheet service = new TimeSheetDAO();
            TimeSheetDTO addTimeSheet = TimeSheetFactory.createTimeSheet(1,date,8,17);
           bool added= service.addTimeSheet(addTimeSheet);
           Assert.IsTrue(added);
            //TEST FIND LAST RECORD
           TimeSheetDTO timesheet = service.getLastReocrd();
           Assert.IsNotNull(timesheet);

            //TEST UPDATE
           //TestUpdate
           TimeSheetDTO update = new TimeSheetDTO.TimeSheetBuilder()
           .copy(timesheet)
           .buildHourIn(24)
           .build();
           service.UpdateTimeSheet(update);
           Assert.AreEqual(24, service.getLastReocrd().hourIn);

        }
    }
}
