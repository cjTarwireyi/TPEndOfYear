using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BusineesLogic.Interface;

/// <summary>
/// Summary description for CustomerDAO
/// </summary>
public class CustomerDAO:ICustomers,IDatabaseFunctions 
{
    private SqlConnection con;
    public CustomerDAO()
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminBookingConnectionString"].ConnectionString);
    }

    public void save(CustomerDTO custDTO)
    {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Customers ([CustomerName],[CustomerSurname],[CustomerCellNumber],[CustomerEmail],[CustomerStreetName],[CustomerSuburb],[CustomerPostalCode],[DateAccountCreated]) values('" + custDTO.name + "','" + custDTO.surname + "','" + custDTO.cellNumber + "','" + custDTO.email + "','" + custDTO.StreetName + "','" + custDTO.Suburb + "','" + custDTO.postalCode + "','" + DateTime.Now + "" + "')";
            cmd.ExecuteNonQuery();
            con.Close();
    }
    public CustomerDTO makeCustDTO(SqlDataReader myDR)
    {
        CustomerDTO customer = new CustomerDTO.CustomerBuilder()
            .custNumber(myDR.GetInt32(0))
            .custName(myDR.GetString(1))
            .custSurname(myDR.GetString(2))
            .custCellNumber(myDR.GetString(3))
            .custEmail(myDR.GetString(4))
            .custAddress(myDR.GetString(5), myDR.GetString(6), myDR.GetString(7))
            .build();
        return customer;
    }

    public CustomerDTO getCustomerID(int number)
    {
            con.Open();
            String selectCustomer = "select * from Customers where CustomerID =" + number + " ";
            SqlCommand myComm = new SqlCommand(selectCustomer, con);
            SqlDataReader myDR;
            myDR = myComm.ExecuteReader();
            if (!myDR.Read())
                return null;
            CustomerDTO updateCustomer = makeCustDTO(myDR);
            con.Close();
            return updateCustomer;
        
    }

    public CustomerDTO getLastReocrd()//last customer
    {
        CustomerDTO customer = new CustomerDTO();
        con.Open();
        String selectCustomer = "SELECT TOP 1 * FROM  Customers Order by CustomerID DESC ";
        SqlCommand myComm = new SqlCommand(selectCustomer, con);
        SqlDataReader myDR;
        myDR = myComm.ExecuteReader();
        if (myDR.Read())
            customer = makeCustDTO(myDR);
        con.Close();
        return customer;
    }
    public DataTable getAllCustomers()
    {
    //  List<CustomerDTO> customers = new List<CustomerDTO>();
        con.Open();
        String selectCustomer = "SELECT  CustomerID, Concat(CustomerName,CustomerSurname) As custName  FROM  Customers Order by CustomerID DESC ";
        SqlCommand myComm = new SqlCommand(selectCustomer, con);
        SqlDataReader myDR;
        DataTable table = new DataTable();
        
        SqlDataAdapter adapter = new SqlDataAdapter(myComm);
        //DataColumn custName = new DataColumn("custName");
        //custName.Expression = string.Format("{0}+'-'+{1}", "CustomerName", "CustomerSurname");

        //table.Columns.Add(custName);
        
        adapter.Fill(table);
        
        //myDR = myComm.ExecuteReader();
        //while (myDR.Read())
        //    customers.Add( makeCustDTO(myDR));
        con.Close();
        return table;
    }
    public DataTable populateGrid()
    {
        DataTable customers = new DataTable();
        string query = "select * from customers";
        con.Open();
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(customers);
        da.Dispose();
        con.Close();
        return customers;
    }

    public void delete(string id)
    {
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "delete from customers where customerID = '"+id+"' ";
        cmd.ExecuteNonQuery();
        con.Close();
    }

    public void update(string id,List<string> customer)
    {
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "update customers set CustomerName ='" + customer[0] + "', CustomerSurname='" + customer[1] + "',CustomerCellNumber='" + customer[2] + "',CustomerEmail='" + customer[3] + "', CustomerStreetName ='" + customer[4] + "',CustomerSuburb='" + customer[5] + "',CustomerPostalCode='" + customer[6] +"' where CustomerID = '"+id+"' ";
        cmd.ExecuteNonQuery();
        con.Close();
    }
}