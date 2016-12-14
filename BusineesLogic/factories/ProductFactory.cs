using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.factories
{
    class ProductFactory
    {
        public static Products createProduct(List<string> productDetails,int quantity,decimal price,int supplierID)
        {
            return new Products.ProductsBuilder()
            .prodName(productDetails[0])
            .prodDescription(productDetails[1])
            .prodQuantity(quantity)
            .prodPrice(price)
            .prodSupplierID(supplierID)
            .prodStatus(true)
            .prodDateArrived(DateTime.Now.ToString())
            .build();
        }
    }
}
