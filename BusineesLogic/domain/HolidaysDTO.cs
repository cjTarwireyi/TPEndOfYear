using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.domain
{
    class HolidaysDTO
    {
        public int employeeID { get; set; }
        public int daysExcludingPublic { get; set; }
        public int sickLeaveDays { get; set; }
        public int religiousHolidays { get; set; }
        private HolidaysDTO() { }

        public HolidaysDTO (HolidaysBuilder holidays)
        {
            this.employeeID = holidays.employeeID;
            this.daysExcludingPublic = holidays.daysExcludingPublic;
            this.sickLeaveDays = holidays.sickLeaveDays;
            this.religiousHolidays = holidays.religiousHolidays;
        }


        public class HolidaysBuilder
        {
            public int employeeID;
            public int daysExcludingPublic;
            public int sickLeaveDays;
            public int religiousHolidays;

            public HolidaysBuilder buildEmpID(int employeeID)
            {
                this.employeeID = employeeID;
                return this;
            }

            public HolidaysBuilder buidlDaysExcPublic(int daysExcludingPublic)
            {
                this.daysExcludingPublic = daysExcludingPublic;
                return this;
            }

            public HolidaysBuilder buildSickLeave(int sickLeaveDays)
            {
                this.sickLeaveDays = sickLeaveDays;
                return this;
            }

            public HolidaysBuilder buildReligiousDays(int religiousHolidays)
            {
                this.religiousHolidays = religiousHolidays;
                return this;
            }

            public HolidaysBuilder build(HolidaysDTO holidays)
            {
                this.employeeID = holidays.employeeID;
                this.daysExcludingPublic = holidays.daysExcludingPublic;
                this.sickLeaveDays = holidays.sickLeaveDays;
                this.religiousHolidays = holidays.religiousHolidays;
                return this;
            }

            public HolidaysDTO build()
            {
                return new HolidaysDTO(this);
            }
        }

    }
}
