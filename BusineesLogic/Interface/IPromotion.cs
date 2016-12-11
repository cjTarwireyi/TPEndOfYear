using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusineesLogic.domain;

namespace BusineesLogic.Interface
{
  public  interface IPromotion
    {
        PromotionDTO getTimeSheet(DateTime date);
        bool ifTimeSheetExis(string id);
        int getTimesheetId(DateTime date);
        bool addTimeSheet(PromotionDTO model);
        bool UpdateTimeSheet(PromotionDTO model);
        PromotionDTO getLastReocrd();

        bool Delete(int id);
    }
}
