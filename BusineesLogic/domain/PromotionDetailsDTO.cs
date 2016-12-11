using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.domain
{
   public class PromotionDetailsDTO
    {
       public PromotionDetailsDTO(PromotionDetailsBuilder promotionBuilder)
       {
           this.discountPercent = promotionBuilder.discountPercent;
           this.startDate = promotionBuilder.startDate;
           this.endDate = promotionBuilder.endDate;
       }
       public PromotionDetailsDTO()
       { }
       
        public decimal discountPercent { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        public  class PromotionDetailsBuilder
        {
            public decimal discountPercent;
            public DateTime startDate;
            public DateTime endDate;
            public PromotionDetailsBuilder buildDiscountPercent(decimal discountPercent)
            {
                this.discountPercent = discountPercent;
                return this;
            }
            public PromotionDetailsBuilder buildStartDate(DateTime startDate)
            {
                this.startDate = startDate;
                return this;
            }
            public PromotionDetailsBuilder buildEndDate(DateTime endDate)
            {
                this.endDate = endDate;
                return this;
            }
            public PromotionDetailsBuilder copy(PromotionDetailsDTO promotionDetails)
            {
                this.discountPercent = promotionDetails.discountPercent;
                this.startDate = promotionDetails.startDate;
                this.endDate = promotionDetails.endDate;
                return this;
            }
            public PromotionDetailsDTO build()
            {
                return new PromotionDetailsDTO(this);
            }
        }
    }
}
