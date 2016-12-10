using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusineesLogic.Interface;
using BusineesLogic.domain;

namespace BusineesLogic.services
{
   public class TimeSheetDAO:ITimeSheet
    {

        public TimeSheetDTO getTimeSheet(DateTime date)
        {
            throw new NotImplementedException();
        }

        public bool ifTimeSheetExis(string id)
        {
            throw new NotImplementedException();
        }

        public int getTimesheetId(DateTime date)
        {
            throw new NotImplementedException();
        }

        public bool addTimeSheet(TimeSheetDTO model)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTimeSheet(TimeSheetDTO model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
