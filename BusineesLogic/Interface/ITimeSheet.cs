using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusineesLogic.domain ;

namespace BusineesLogic.Interface
{
    public interface ITimeSheet
    {
        TimeSheetDTO getTimeSheet(DateTime date);
        bool ifTimeSheetExis(string id);
        int getTimesheetId(DateTime date);
        bool addTimeSheet(TimeSheetDTO model);
        bool UpdateTimeSheet(TimeSheetDTO model);
        bool Delete(int id);
    }
}
