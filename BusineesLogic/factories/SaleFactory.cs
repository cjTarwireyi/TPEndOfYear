using BusineesLogic.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.factories
{
    public class SaleFactory
    {
        public static SaleDTO createSale(List<int> saleDetails)
        {
            return new SaleDTO.SaleBuilder()
                            .buildProductID(saleDetails[0])
                            .buildOriginalPrice(Convert.ToDecimal(saleDetails[1]))
                            .buildSalePrice(Convert.ToDecimal(saleDetails[2]))
                            .buildSaleActive(true)
                            .build();
        }
    }
}
