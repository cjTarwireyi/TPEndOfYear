using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.factories;
using BusineesLogic.repositories;
using BusineesLogic.domain;
using BusineesLogic.repositories.Impl;
namespace UnitTests.repositories
{
    [TestClass]
    public class TestTimesheetRepository
    {
        [TestMethod]
        public void TestTimesheetRepo()
        {
            //CREATE TEST
            DateTime date = DateTime.Parse("1/1/1900 12:00:00 AM");
            TimeSheetRepositoryImpl repo = new TimeSheetRepositoryImpl();
            //CREATE TEST


            TimeSheetDTO addTimeSheet = TimeSheetFactory.createTimeSheet(1, date, "10:00", "17:00", "comments");
            bool added = repo.addTimeSheet(addTimeSheet);
            Assert.IsTrue(added);
            //TEST FIND LAST RECORD
            TimeSheetDTO timesheet = repo.getLastReocrd();
            Assert.IsNotNull(timesheet);

            //TEST UPDATE

            TimeSheetDTO update = new TimeSheetDTO.TimeSheetBuilder()
            .copy(timesheet)
            .buildTimeIn("11:00")
            .build();
            repo.UpdateTimeSheet(update);
            Assert.AreEqual("11:00", repo.getLastReocrd().timeIn.Trim());

            //TEST DELETE
            bool deleted = repo.Delete(repo.getLastReocrd().id);
            Assert.IsTrue(deleted);


        }
    }
}
