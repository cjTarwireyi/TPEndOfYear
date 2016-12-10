using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.domain
{
    public class TimeSheetDTO
    {
        public TimeSheetDTO(TimeSheetBuilder timeSheetBuilder)
        {
            this.id = timeSheetBuilder.id;
            this.day = timeSheetBuilder.day;
            this.hour = timeSheetBuilder.hour;
            this.minutes = timeSheetBuilder.minutes;

        }
        public int id { get; set; }
        public int day { get; set; }
        public int hour { get; set; }
        public int minutes { get; set; }

        public class TimeSheetBuilder
        {
            public int id;
            public int day;
            public int hour;
            public int minutes;

            public TimeSheetBuilder buildId(int id)
            {
                this.id = id;
                return this;
            }
            public TimeSheetBuilder buildDay(int day)
            {
                this.day = day;
                return this;
            }
            public TimeSheetBuilder buildHour(int hour)
            {
                this.hour = hour;
                return this;
            }
            public TimeSheetBuilder buildMinutes(int minutes)
            {
                this.minutes = minutes;
                return this;
            }
            public TimeSheetBuilder copy(TimeSheetDTO timesheetDto)
            {
                this.id = timesheetDto.id;
                this.day = timesheetDto.day;
                this.hour = timesheetDto.hour;
                this.minutes = timesheetDto.minutes;
                return this;
            }
            public TimeSheetDTO build()
            {
                return new TimeSheetDTO(this);
            }
        }


    }
}
