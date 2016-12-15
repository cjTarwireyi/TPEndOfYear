using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.domain
{
    public class SaleDTO
    {
        public int id { get; set; }
        public int productID { get; set; }
        public decimal originalPrice { get; set; }
        public decimal salePrice { get; set; }
        public bool saleActive { get; set; }

        private SaleDTO() { }
        public SaleDTO (SaleBuilder sale)
        {
            this.id = sale.id;
            this.productID = sale.productID;
            this.originalPrice = sale.originalPrice;
            this.salePrice = sale.salePrice;
            
        }
        public class SaleBuilder
        {
            public int id;
            public int productID;
            public decimal originalPrice;
            public decimal salePrice;
            public bool saleActive;

            public SaleBuilder buildId(int id)
            {
                this.id = id;
                return this;
            }

            public SaleBuilder buildProductID(int productID)
            {
                this.productID = productID;
                return this;
            }

            public SaleBuilder buildOriginalPrice(decimal originalPrice)
            {
                this.originalPrice = originalPrice;
                return this;
            }

            public SaleBuilder buildSalePrice(decimal salePrice)
            {
                this.salePrice = salePrice;
                return this;
            }

            public SaleBuilder buildSaleActive(bool saleActive)
            {
                this.saleActive = saleActive;
                return this;
            }


            public SaleBuilder copy(SaleDTO sale)
            {
                this.id = sale.id;
                this.productID = sale.productID;
                this.originalPrice = sale.originalPrice;
                this.salePrice = sale.salePrice;
                return this;
            }


            public SaleDTO build()
            {
                return new SaleDTO(this);
            }
        }
    }
}
