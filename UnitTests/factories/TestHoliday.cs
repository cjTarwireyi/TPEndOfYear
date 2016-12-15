using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.domain;
using BusineesLogic.factories;

namespace UnitTests.factories
{
    [TestClass]
    public class TestHoliday
    {
        [TestMethod]
        public void testCreateHoliday()
        {
            HolidaysDTO holiday = Holidayfactory.createHolidays(12,5,1);
            Assert.AreEqual(holiday.daysExcludingPublic.ToString(), "12");

        }

        [TestMethod]
        public void testUpdateHolidays()
        {
            HolidaysDTO holiday = Holidayfactory.createHolidays(12, 5, 1);
            HolidaysDTO updateHoliday = new HolidaysDTO.HolidaysBuilder()
                                        .copy(holiday)
                                        .buidlDaysExcPublic(13)
                                        .build();

            Assert.AreNotEqual(holiday.daysExcludingPublic, updateHoliday.daysExcludingPublic);

        }
    }
}
