using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusineesLogic.domain;

namespace BusineesLogic.factories
{
    public class PromotionDetailsFactory
    {
        public static PromotionDetailsDTO createPromotionDetails(decimal discount, DateTime startDate, DateTime endDate)
        {
            return new PromotionDetailsDTO.PromotionDetailsBuilder()

                .buildDiscountPercent(discount)
                .buildStartDate( startDate)
                .buildEndDate(endDate)
                .build();

        }
    }
}
