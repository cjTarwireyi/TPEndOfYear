using BusineesLogic.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.factories
{
    public class Holidayfactory
    {
        public static HolidaysDTO createHolidays(int holidays,int sickDays,int religiousDays)
        {
            return new HolidaysDTO.HolidaysBuilder()
            .buidlDaysExcPublic(holidays)
            .buildSickLeave(sickDays)
            .buildReligiousDays(religiousDays)
            .build();
        }
    }
}
