using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System;
using BusineesLogic.repositories.Impl;



/// <summary>
/// Summary description for OrderLineDAO
/// </summary>
public class OrderLineDAO : InterfaceOrderLine
{
    private OrderLineRepositoryImpl repo = new OrderLineRepositoryImpl();
    public OrderLineDAO(){}
    public bool AddOderLine(List<OrderLineDTO> model)
    {
        return repo.AddOderLine(model);   
    }
    public bool RemoveProduct(OrderLineDTO model)
    {
        return repo.RemoveProduct(model);
    }
    public bool UpdateOrderLine(OrderLineDTO model)
    {
        return repo.UpdateOrderLine(model);
    }

    public List<OrderLineDTO> getOrderItems(int orderID)
    {
       return repo.getOrderItems(orderID);
    }

    public void updateInsertOrder(string orderID, string productID, string quantity)
    {
        repo.updateInsertOrder(orderID, productID, quantity);
    }

    public void removeItem(string id, string orderline)
    {
        repo.removeItem(id,orderline);
    }
    public void updateQuantity(string productID, string orderlineID)
    {
        repo.updateQuantity(productID,orderlineID);
    }

    public void updateQty(List<string> orderline)
    {
        repo.updateQty(orderline);
    }

    public DataTable getAllOrders(string id)
    {
       return repo.getAllOrders(id);
    }
}