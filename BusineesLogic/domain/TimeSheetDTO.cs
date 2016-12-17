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
            this.timeIn = timeSheetBuilder.timeIn;
            this.timeOut = timeSheetBuilder.timeOut;
            this.comments = timeSheetBuilder.comments;

        }
        public int id { get; set; }
        public int employeeId { get; set; }

        public DateTime date { get; set; }
        public string timeOut { get; set; }
        public string timeIn { get; set; }
        public string comments { get; set; }
       // public int minutes { get; set; }

        public class TimeSheetBuilder
        {
            public int id;
            public int employeeId;
            public DateTime date;
            public string timeIn;
            public string timeOut;
            public string comments;

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
            public TimeSheetBuilder buildTimeIn(string timeIn)
            {
                this.timeIn = timeIn;
                return this;
            }
            public TimeSheetBuilder buildTimeOut(string timeOut)
            {
                this.timeOut = timeOut;
                return this;
            }
            public TimeSheetBuilder buildComments(string comments)
            {
                this.comments = comments;
                return this;
            }
            public TimeSheetBuilder copy(TimeSheetDTO timesheetDto)
            {
                this.id = timesheetDto.id;
                this.employeeId = timesheetDto.employeeId;
                this.date = timesheetDto.date;
                this.timeIn = timesheetDto.timeIn;
                this.timeOut = timesheetDto.timeOut;
                this.comments = timesheetDto.comments;
                return this;
            }
            public TimeSheetDTO build()
            {
                return new TimeSheetDTO(this);
            }
        }


    }
}
