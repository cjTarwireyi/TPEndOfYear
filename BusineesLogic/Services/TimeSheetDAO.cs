using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusineesLogic.Interface;
using System.Data.SqlClient;
using System.Configuration;
using BusineesLogic.factories;
using System.Data;
using BusineesLogic.domain;
using BusineesLogic.repositories.Impl;

namespace BusineesLogic.services
{
   public class TimeSheetDAO:ITimeSheet
    {
       private TimeSheetRepositoryImpl repo = new TimeSheetRepositoryImpl();
       public TimeSheetDAO() { }
        

        public TimeSheetDTO getTimeSheet(DateTime date)
        {
            throw new NotImplementedException();
        }
        public DataTable findAll()
        {
            return repo.findAll();
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
            return repo.addTimeSheet(model);
        }

        public bool UpdateTimeSheet(TimeSheetDTO model)
        {
           return repo.UpdateTimeSheet( model);
        }

        public bool Delete(int id)
        {
            return  repo.Delete(id);
        }


        public TimeSheetDTO getLastReocrd()
        {
            return repo.getLastReocrd();
        }
    }
}
