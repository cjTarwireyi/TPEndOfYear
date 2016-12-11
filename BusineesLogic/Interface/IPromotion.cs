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
        bool ifExis(string id);
        int getId(DateTime date);
        bool add(PromotionDTO model);
        bool Update(PromotionDTO model);
        PromotionDTO getLastReocrd();

        bool Delete(int id);
    }
}
