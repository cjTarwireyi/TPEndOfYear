using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.repositories.Impl
{
    public class CustomerRepositoryImpl : CustomerRepository
    {
    
        private SqlConnection con;

        public CustomerRepositoryImpl()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminBookingConnectionString"].ConnectionString);
        }

        public void save(CustomerDTO entity)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Customers ([CustomerName],[CustomerSurname],[CustomerCellNumber],[CustomerEmail],[CustomerStreetName],[CustomerSuburb],[CustomerPostalCode],[DateAccountCreated]) values('" + entity.name + "','" + entity.surname + "','" + entity.cellNumber + "','" + entity.email + "','" + entity.StreetName + "','" + entity.Suburb + "','" + entity.postalCode + "','" + DateTime.Now + "" + "')";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void update(CustomerDTO entity)
        {
            throw new NotImplementedException();
        }

        public void delete(int id)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from customers where customerID = '" + id + "' ";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public System.Data.DataTable findAll()
        {
            DataTable customers = new DataTable();
            string query = "select * from customers order by customerID DESC";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(customers);
            da.Dispose();
            con.Close();
            return customers;
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
                .accountCreatedDate(myDR.GetString(8).ToString())
                .build();
            return customer;
        }

        public CustomerDTO findByID(int id)
        {
            con.Open();
            String selectCustomer = "select * from Customers where CustomerID =" + id + " ";
            SqlCommand myComm = new SqlCommand(selectCustomer, con);
            SqlDataReader myDR;
            myDR = myComm.ExecuteReader();
            if (!myDR.Read())
                return null;
            CustomerDTO updateCustomer = makeCustDTO(myDR);
            con.Close();
            return updateCustomer;
        }

        public void updateCustomer(string id, List<string> customer)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update customers set CustomerName ='" + customer[0] + "', CustomerSurname='" + customer[1] + "',CustomerCellNumber='" + customer[2] + "',CustomerEmail='" + customer[3] + "', CustomerStreetName ='" + customer[4] + "',CustomerSuburb='" + customer[5] + "',CustomerPostalCode='" + customer[6] + "' where CustomerID = '" + id + "' ";
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public DataTable searchCustomer(string id)
        {
            DataTable customers = new DataTable();
            string query = "select * from customers where customerID = '" + id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(customers);
            da.Dispose();
            con.Close();
            return customers;
        }
        public DataTable getAllCustomers()
        {
            //  List<CustomerDTO> customers = new List<CustomerDTO>();
            con.Open();
            String selectCustomer = "SELECT  CustomerID, Concat(CustomerName,CustomerSurname) As custName  FROM  Customers Order by CustomerName DESC ";
            SqlCommand myComm = new SqlCommand(selectCustomer, con);
            SqlDataReader myDR;
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(myComm);
            adapter.Fill(table);
            con.Close();
            return table;
        }

        public CustomerDTO getLastReocrd()//last customer
        {
            CustomerDTO customer = null;
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
    }
}
