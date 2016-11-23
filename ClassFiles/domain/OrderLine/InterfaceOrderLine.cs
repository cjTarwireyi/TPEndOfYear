using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for InterfaceOrderLine
/// </summary>
public interface InterfaceOrderLine
{
    bool AddOderLine(List<OrderLineDTO> model);
    bool RemoveProduct(OrderLineDTO model);
    bool UpdateOrderLine(OrderLineDTO model);
}