using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.domain
{
    public class PromotionDTO
    {
        private PromotionDTO() { }
        public PromotionDTO(PromotionBuilder promotionBuilder)
        {
            this.id = promotionBuilder.id;
            this.productId = promotionBuilder.productId;
            this.dateCreated = promotionBuilder.createdDate;
            this.promotionDetails = promotionBuilder.promotionDetails;

        }
        public int id { get; set; }
        public int productId { get; set; }
        
        public DateTime dateCreated { get; set; }
        public PromotionDetailsDTO promotionDetails{get;set;}
        public  class PromotionBuilder
        {
            public int id;
            public int productId;             
            public DateTime createdDate;
            public PromotionDetailsDTO promotionDetails;

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
            
            public PromotionBuilder buildDateCreated(DateTime createdDate)
            {
                this.createdDate = createdDate;
                return this;
            }
            public PromotionBuilder buildPromotionDetails(PromotionDetailsDTO promotionDetails)
            {
                
                this.promotionDetails = promotionDetails;
                return this;
            }
            public PromotionBuilder copy(PromotionDTO promotionDTO)
            {
                this.id = promotionDTO.id;
                this.productId = promotionDTO.productId;               
                this.createdDate = promotionDTO.dateCreated;
                this.promotionDetails = promotionDTO.promotionDetails;
                return this;
            }
            public PromotionDTO build()
            {
                return new PromotionDTO(this);
            }
        }
    }
}
