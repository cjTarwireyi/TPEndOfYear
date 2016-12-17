using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using BusineesLogic.Interface;
using BusineesLogic.repositories.Impl;

/// <summary>
/// Summary description for ProductDAO
/// </summary>
public class ProductDAO : IProduct
{
    private ProductRepositoryImpl repo = new ProductRepositoryImpl();

    public ProductDAO() { }
    public void save(Products product)
    {
        repo.save(product);
    }

    public void updateProduct(Products product)
    {
        repo.update(product);
    }

    public Products getProduct(int id)
    {
        return repo.findByID(id);
    }


    //decreases quantint when Item is purchased
    public void updateQuantity(int prodId, int qty)
    {
        repo.updateQuantity(prodId, qty);
    }


    public void itemBought(string productID, string quantity, string opr)
    {
        repo.itemBought(productID, quantity, opr);
    }

    public void qutyUpdaeHelper(int newQuantity, int productID)
    {
        repo.qutyUpdaeHelper(newQuantity, productID);

    }
    public int getItemQuantity(string id)
    {
        return repo.getItemQuantity(id);
    }

    public DataTable populateGrid()
    {
        return repo.findAll();
    }

    public DataTable populateInactiveProducts()
    {
        return repo.populateInactiveProducts();
    }

    public SqlDataReader loadSuppliers()
    {
        return repo.loadSuppliers();
    }

    public void connectionClosed()
    {
        repo.connectionClosed();
    }

    public void updateProductStatus(string id, bool state)
    {
        repo.updateProductStatus(id, state);
    }

    public void delete(string id)
    {
        repo.delete(Convert.ToInt32(id));
    }

    public void update(string id, List<string> productDetails)
    {
        repo.updateProduct(id, productDetails);
    }

    public DataTable mostSoldProducts()
    {
        return repo.mostSoldProducts();
    }


    public DataTable mostReturnedProducts()
    {
        return repo.mostReturnedProducts();
    }

    public DataTable monthlyAmount(string year, bool amountDueOrMade)
    {
        return repo.monthlyAmount(year, amountDueOrMade);
    }


    public DataTable generateCustomersOrderHistory(bool paid)
    {
        return repo.generateCustomersOrderHistory(paid);
    }

    public DataTable loadNotification()
    {
        return repo.loadNotification();
    }

    public DataTable searchProducts(string id, bool active)
    {
        return repo.searchProducts(id,active);
    }

    public Products getLastReocrd()
    {
        return repo.getLastReocrd();
    }
}