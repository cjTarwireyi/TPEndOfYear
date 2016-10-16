﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrderFacade
/// </summary>
public class OrderFacade
{
    InterfaceOrderLine orderLineservice;
    InterfaceOder orderService;
    OrderLineDTO orderLineDTO;
	public OrderFacade()
	{
        orderLineDTO = new OrderLineDTO();
        orderLineservice = new OrderLineDAO();
        orderService = new OrdersDAO();
	}
    public OrderDTO makeOrder(OrderDTO order)
    {
       // makeOrderLine(order);
      int orderId =  orderService.AddOrder(order);
      makeOrderLine(order.orderItems, orderId);
        return order;
    }
    private bool makeOrderLine(List< Products> products, int orderId)
    {
        List<OrderLine> range = new List<OrderLine>();
        OrderLine ol = new OrderLine();
        foreach (var product in products)
        {
            ol.OrderID = orderId; 
            ol.ProductID = product.productNumber;
            ol.ProductID = product.productQuantity;
            range.Add(ol);
        }
        orderLineservice.AddOderLine(range);
        
        


        return true;
    }
}