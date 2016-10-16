using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CustomerDAO
/// </summary>
public class CustomerDAO
{
    private SqlConnection con;
	public CustomerDAO()
	{
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminBookingConnectionString"].ConnectionString);
	}

    public void saveCustomer(CustomerDTO custDTO)
    {
        try
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Customers ([CustomerName],[CustomerSurname],[CustomerCellNumber],[CustomerEmail],[CustomerStreetName],[CustomerSuburb],[CustomerPostalCode]) values('" + custDTO.name + "','" + custDTO.surname + "','" + custDTO.cellNumber + "','"+custDTO.email+"','" + custDTO.StreetName + "','" + custDTO.Suburb + "','" + custDTO.postalCode + "')";
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
    public CustomerDTO makeCustDTO(SqlDataReader myDR)
    {
        CustomerDTO customer = new CustomerDTO();
        customer.customerNumber = myDR.GetInt32(0);
        customer.name = myDR.GetString(1) + " " + myDR.GetString(2);
        customer.cellNumber = myDR.GetString(3);
        customer.email = myDR.GetString(4);
        customer.postalCode = myDR.GetString(5);
        customer.StreetName = myDR.GetString(6);
        customer.Suburb = myDR.GetString(7);

        //booking.Hours = myDR.GetInt32(8);
        return customer;

    }

    public CustomerDTO getCustomer(int number)
    {
        con.Open();
        String selectCustomer = "select * from Customer where custID =" + number + " ";
        SqlCommand myComm = new SqlCommand(selectCustomer, con);
        SqlDataReader myDR;
        myDR = myComm.ExecuteReader();
        if (!myDR.Read())
            return null;
        CustomerDTO updateCustomer = makeCustDTO(myDR);
        con.Close();
        return updateCustomer;
    }
}