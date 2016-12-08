using BusineesLogic.domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.services
{

    public class ReturnDAO
    {
        private SqlConnection con;
        
        public ReturnDAO()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminBookingConnectionString"].ConnectionString);
        }

        public DataTable searchOrder(string orderNumber,string customerNumber)
        {
            DataTable order = new DataTable();
            string query = @"select orders.orderId AS ORDER_ID ,orderline.ProductID AS PRODUCT_ID,Products.ProductName AS PRODUCT_NAME,orderline.OrderLineID
                             from customers
                             inner join orders
                             on customers.CustomerID = Orders.custId
                             inner join orderline
                             on orders.orderId = orderline.OrderID
                             inner join Products
                             on orderline.ProductID = Products.Id
                             where orders.orderId = '"+orderNumber+"' and customers.CustomerID = '"+customerNumber+"' ";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(order);
            da.Dispose();
            con.Close();

            return order;
        }

        public void save(ReturnDTO returns)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Returns ([OrderID],[CustomerID],[ProductID],[DateReturned]) values('" + returns.orderID + "','" + returns.customerID + "','" + returns.productID + "','" + DateTime.Now.ToString() + "')";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        
    }
}
