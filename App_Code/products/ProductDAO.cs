using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductDAO
/// </summary>
public class ProductDAO
{
    private SqlConnection con;
    public ProductDAO()
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminBookingConnectionString"].ConnectionString);
    }

    public void saveProduct(Products product)
    {

        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "insert into Products([ProductName], [ProductDescription], [Quantity],[Price], [Active],[DateArrived],[SupplierID])values('" + product.productName + "','" + product.productDescription + "','" + product.productQuantity + "','" + product.price + "','" + product.productStatus + "','" + product.dateArrived + "','" + product.productSupplierID + "')";
        cmd.ExecuteNonQuery();
        con.Close();
    }


    public Products makeProductDTO(SqlDataReader myDR)
    {
        Products product = new Products();
        product.productNumber = myDR.GetInt32(0);
        product.productName = myDR.GetString(1);
        product.productDescription = myDR.GetString(2);
        product.price = myDR.GetDecimal(3);
        product.productQuantity = myDR.GetInt32(4);
        product.productStatus = myDR.GetBoolean(5);
        product.dateArrived = myDR.GetDateTime(6);
        product.productSupplierID = myDR.GetInt32(7);
        return product;

    }

    public Products getProduct(int id)
    {
        con.Open();
        String selectProduct = "select * from Products where Id =" + id + " ";
        SqlCommand myComm = new SqlCommand(selectProduct, con);
        SqlDataReader myDR;
        myDR = myComm.ExecuteReader();
        if (!myDR.Read())
            return null;
        Products updateProduct = makeProductDTO(myDR);
        con.Close();
        return updateProduct;
    }


    public SqlConnection connection()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminBookingConnectionString"].ConnectionString);
        return con;
    }

    public void itemBought(string productID, string quantity)
    {
        string oriQuantity = "";
        int newQuantity = 0;
        DataTable productQuantity = new DataTable();
        con.Open();

        string getQuantity = "select quantity from products where id ='" + productID + "' ";
        SqlCommand cmd = new SqlCommand(getQuantity, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(productQuantity);
        da.Dispose();
        foreach (DataRow row in productQuantity.Rows)
        {
            oriQuantity = row["Quantity"].ToString();
        }

        newQuantity = Convert.ToInt32(oriQuantity) - Convert.ToInt32(quantity);
        string updateQuery = "update products set quantity = '" + newQuantity + "' where id ='" + productID + "' ";
        cmd = new SqlCommand(updateQuery, con);
        cmd.ExecuteNonQuery();

        con.Close();
    }


    public int getItemQuantity(string id)
    {
        int quantity = 0;
        DataTable prodQuantity = new DataTable();
        con.Open();

        string query = "select quantity from products where id = '" + id + "' ";
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(prodQuantity);
        da.Dispose();
        foreach (DataRow row in prodQuantity.Rows)
        {
            quantity = Convert.ToInt32(row["Quantity"].ToString());
        }
        cmd.ExecuteNonQuery();

        con.Close();
        return quantity;
    }

    public DataTable populateGrid()
    {
        DataTable products = new DataTable();
        bool status = true;
        string query = "select * from products where active ='" + status + "' ";
        con.Open();
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(products);
        da.Dispose();
        con.Close();
        return products;
    }

    public DataTable populateInactiveProducts()
    {
        DataTable products = new DataTable();
        bool status = false;
        string query = "select * from products where active ='" + status + "' ";
        con.Open();
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(products);
        da.Dispose();
        con.Close();
        return products;
    }
}