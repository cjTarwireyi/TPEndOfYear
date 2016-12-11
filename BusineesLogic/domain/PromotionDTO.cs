using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.domain
{
    public class PromotionDTO
    {
        public int id { get; set; }
        public int productId { get; set; }
        public decimal discountPercent { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public DateTime dateCreated { get; set; }

        public class PromotionBuilder
        {
            public int id;
            public int productId;
            public decimal discountPercent;
            public DateTime startDate;
            public DateTime endDate;
            public DateTime createdDate;

            public PromotionBuilder buildId(int id)
            {
                this.id = id;
                return this;
            }
            public PromotionBuilder BuildProductId(int productId)
            {
                this.productId = productId;
                return this;
            }
            public PromotionBuilder buildDiscountPercent(decimal discountPercent)
            {
                this.discountPercent = discountPercent;
                return this;
            }
            public PromotionBuilder buildStartDate(DateTime startDate)
            {
                this.startDate = startDate;
                return this;
            }
            public PromotionBuilder buildEndDate(DateTime endDate)
            {
                this.endDate = endDate;
                return this;
            }
            public PromotionBuilder buildDateCreated(DateTime createdDate)
            {
                this.createdDate = createdDate;
                return this;
            }
            public PromotionBuilder copy(PromotionDTO promotionDTO)
            {
                this.id = promotionDTO.id;
                this.productId = promotionDTO.productId;
                this.discountPercent = promotionDTO.discountPercent;
                this.startDate = promotionDTO.startDate;
                this.endDate = promotionDTO.endDate;
                this.createdDate = promotionDTO.dateCreated;
                return this;
            }
        }
    }
}
