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
            this.employeeId = timeSheetBuilder.employeeId;
            this.date = timeSheetBuilder.date;
            this.hourIn = timeSheetBuilder.hourIn;
            this.hourOut = timeSheetBuilder.hourOut;

        }
        public int id { get; set; }
        public int employeeId { get; set; }

        public DateTime date { get; set; }
        public int hourIn { get; set; }
        public int hourOut { get; set; }
       // public int minutes { get; set; }

        public class TimeSheetBuilder
        {
            public int id;
            public int employeeId;
            public DateTime date;
            public int hourIn;
            public int hourOut;
           // public int minutes;

            public TimeSheetBuilder buildId(int id)
            {
                this.id = id;
                return this;
            }
            public TimeSheetBuilder buildEmployeeID(int employeeId){
                this.employeeId = employeeId;
                return this;
            }
            public TimeSheetBuilder buildDate(DateTime date)
            {
                this.date = date;
                return this;
            }
            public TimeSheetBuilder buildHourIn(int hourIn)
            {
                this.hourIn = hourIn;
                return this;
            }
            public TimeSheetBuilder buildHourOut(int hourOut)
            {
                this.hourOut = hourOut;
                return this;
            }
            public TimeSheetBuilder copy(TimeSheetDTO timesheetDto)
            {
                this.id = timesheetDto.id;
                this.employeeId = timesheetDto.employeeId;
                this.date = timesheetDto.date;
                this.hourIn = timesheetDto.hourIn;
                this.hourOut = timesheetDto.hourOut;
                return this;
            }
            public TimeSheetDTO build()
            {
                return new TimeSheetDTO(this);
            }
        }


    }
}
