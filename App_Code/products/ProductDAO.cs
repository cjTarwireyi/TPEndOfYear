﻿using System;
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
        try
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            // cmd.CommandText = "insert into Technician([techName], [techSurname], [techContact], [techEmail],[StreetName],[Suburb],[PostalCode],[password],[username])values('" + emp.name + "','" + emp.surname + "','" + emp.cellNumber + "','" + emp.email + "','" + emp.streetName + "','" + emp.suburb + "','" + emp.postalCode + "','" + emp.password + "','" + emp.username + "')";
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception e)
        {
        }
        finally
        {
            con.Close();
        }
    }


    public Products makeProductDTO(SqlDataReader myDR)
    {
        Products product = new Products();
        product.productNumber = myDR.GetInt32(0);
        return product;
    }

    public Products getProduct(int id)
    {
        con.Open();
        //String selectProduct = "select * from Technician where techID =" + techNumber + " ";
        //SqlCommand myComm = new SqlCommand(selectProduct, con);
        SqlDataReader myDR;
        /*myDR = myComm.ExecuteReader();
        if (!myDR.Read())
            return null;
        Products updateProduct = makeProductDTO(myDR);
        con.Close();
        return updateProduct;*/
        return null;
    }
}