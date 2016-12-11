using System;
using System.Collections.Generic;
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


namespace BusineesLogic.services
{
    public class PromotionDAO:IPromotion
    {
        public PromotionDTO getTimeSheet(System.DateTime date)
        {
            throw new System.NotImplementedException();
        }

        public bool ifTimeSheetExis(string id)
        {
            throw new System.NotImplementedException();
        }

        public int getTimesheetId(System.DateTime date)
        {
            throw new System.NotImplementedException();
        }

        public bool addTimeSheet(PromotionDTO model)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateTimeSheet(PromotionDTO model)
        {
            throw new System.NotImplementedException();
        }

        public PromotionDTO getLastReocrd()
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
