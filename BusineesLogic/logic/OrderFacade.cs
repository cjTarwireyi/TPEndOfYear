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
    IOder orderService;
    
    OrderLineDTO orderLineDTO;
    ProductDAO product;
    CustomerDAO cust;
	public OrderFacade()
	{
        orderLineDTO = new OrderLineDTO();
        orderLineservice = new OrderLineDAO();
        orderService = new OrdersDAO();
        product = new ProductDAO();
        cust = new CustomerDAO();
	}
    public string findCustomer(int id)
    {
      var found = cust.getCustomerID(id);
        if(found == null){
            return "401";

        }
        else { return "200"; }
    }
    public Products findProduct(int id)
    {
      Products found = product.getProduct(id);
        if(found == null){
            return null;

        }
        else { return found; }
    }
    public OrderDTO makeOrder(OrderDTO order)
    {
       // makeOrderLine(order);
     orderService.AddOrder(order);
     OrdersDAO accessOrder = new OrdersDAO();
     OrderDTO lastOrder = new OrderDTO();
     lastOrder = accessOrder.getLastReocrd();
     makeOrderLine(order.orderItems, lastOrder.orderId);
        return order;
    }
    private bool makeOrderLine(List< Products> products, int orderId)
    {
        List<OrderLineDTO> range = new List<OrderLineDTO>();
        OrderLineDTO ol;
        foreach (var product in products)
        {
            ol = new OrderLineDTO();
            ol.orderId = orderId; 
            ol.productID = product.productNumber;
            ol.quantity = product.productQuantity;
            range.Add(ol);
        }
        orderLineservice.AddOderLine(range);
        return true;
    }
}