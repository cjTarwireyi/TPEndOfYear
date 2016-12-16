using BusineesLogic.domain;
using BusineesLogic.repositories.Impl;
using BusineesLogic.services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Orders
/// </summary>
public class OrdersDAO : IOder
{
    private OrderRepositoryImpl repo = new OrderRepositoryImpl();

    public OrdersDAO() { }
     
    

    public int AddOrder(OrderDTO order)
    {
        return repo.AddOrder(order);
    }
    public bool UpdateOrder(OrderDTO model)
    {
        return repo.UpdateOrder(model);
    }
    public bool deleteOrder(int orderId)
    {
        return repo.deleteOrder(orderId);
    }

    public OrderDTO getLastReocrd()
    {
        return repo.getLastReocrd();
    }

    public OrderDTO getOrderByID(int id)
    {
        return repo.findByID(id);
    }
    public DataTable getOrdersDetails(DataTable productsOrdered, int orderID)
    {
        return repo.getOrdersDetails(productsOrdered, orderID);
    }
    public DataTable searchOrder(DataTable orderRecord, string id, bool status)
    {
        return repo.searchOrder(orderRecord,id,status);
    }
    
    public DataTable populateGrid(string month, string year, bool status)
    {
        return repo.populateGrid(month,year,status);
    }

    public void calculateOrder(string orderID,string customerID)
    {

        repo.calculateOrder(orderID, customerID); 
    }
    public void updateAmount(string id,int amount)
    {
        repo.updateAmount(id, amount);
    }

    public void paid(string id)
    {
        repo.paid(id);
    }
    public DataTable searchGrid(DataTable orders, string date, bool payed)
    {
        return repo.searchGrid(orders, date, payed);
    }
    public void cancelOrder(string orderNo)
    {
        repo.cancelOrder(orderNo);
    }
}