using BusineesLogic.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.factories
{
    class EmployeeHolidayFactory
    {
        public static HolidaysDTO createDaysOffRecord(List<int> details)
        {
            return new HolidaysDTO.HolidaysBuilder()
                        .buidlDaysExcPublic(details[0])
                        .buildSickLeave(details[1])
                        .buildReligiousDays(details[2])
                        .build();
        }
    }
}
