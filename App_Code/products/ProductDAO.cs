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
        //try
        //{
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Products([ProductName], [ProductDescription], [Quantity],[Price], [Active],[DateArrived],[SupplierID])values('" + product.productName + "','" + product.productDescription + "','" + product.productQuantity + "','"+product.price+"','" +product.productStatus+ "','" +product.dateArrived+ "','"+product.productSupplierID+"')";
            cmd.ExecuteNonQuery();
            con.Close();
        //}
        //catch (Exception e)
        //{
        //}
        //finally
        //{
        //    con.Close();
        //}
    }


    public Products makeProductDTO(SqlDataReader myDR)
    {
        try
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
        catch(Exception e)
        { 
            return null;
        }
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

}