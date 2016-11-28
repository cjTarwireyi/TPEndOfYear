using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.factories
{
    public class OrderLineFactory
    {
        public static OrderLineDTO createOrderLine(int orderId, int prodId, int quantity)
        {            
            return new OrderLineDTO.OrderLineBuilder()
            .buildOrderId(orderId)
            .buildProductId(prodId)
            .buildQuantity(quantity)
            .build();
        }

    }
}
