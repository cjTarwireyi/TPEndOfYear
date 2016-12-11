using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusineesLogic.domain;

namespace BusineesLogic.factories
{
    public class PromotionFactory
    {
        public static PromotionDTO createRole( int productID, PromotionDetailsDTO promotionDetails,DateTime dateCreated)
        {
            return new PromotionDTO.PromotionBuilder()

             
            .BuildProductId(productID)
            .buildPromotionDetails(promotionDetails)
            .buildDateCreated(dateCreated)
            .build();

        }
    }
}
