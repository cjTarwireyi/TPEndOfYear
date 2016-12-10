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
        TimeSheetDTO getTimeSheet(string username, string password);
        bool ifTimeSheetExis(string username);
        int getTimesheetId(string username);
        bool addTimeSheet(TimeSheetDTO model);
        bool UpdateTimeSheet(TimeSheetDTO model);
        bool Delete(int id);
    }
}
