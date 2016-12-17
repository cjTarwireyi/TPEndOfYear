using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusineesLogic.domain;

namespace BusineesLogic.factories
{
   public class TimeSheetFactory
    {
       public static TimeSheetDTO createTimeSheet(int employeeId, DateTime date, string timeIn, string timeOut,string comments)
       {
           return new TimeSheetDTO.TimeSheetBuilder()
           .buildEmployeeID(employeeId)
           .buildDate(date)
           .buildTimeIn(timeIn)
           .buildTimeOut(timeOut)
           .buildComments(comments)
           .build();
       }
        
    }
}
