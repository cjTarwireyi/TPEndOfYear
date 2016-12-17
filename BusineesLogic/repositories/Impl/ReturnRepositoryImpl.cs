using BusineesLogic.domain;
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
    public class ReturnRepositoryImpl : ReturnRepository
    {
        private SqlConnection con;

        public ReturnRepositoryImpl()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminBookingConnectionString"].ConnectionString);
        }

        public void save(domain.ReturnDTO entity)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Returns ([OrderID],[CustomerID],[ProductID],[DateReturned],[Quantity]) values('" + entity.orderID + "','" + entity.customerID + "','" + entity.productID + "','" + DateTime.Now.ToString() + "','" + entity.quantity + "')";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void update(domain.ReturnDTO entity)
        {
            throw new NotImplementedException();
        }

        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable findAll()
        {
            throw new NotImplementedException();
        }

        public domain.ReturnDTO findByID(int id)
        {
            throw new NotImplementedException();
        }

        public DataTable searchOrder(string orderNumber, string customerNumber)
        {
            DataTable order = new DataTable();
            string query = @"select orders.orderId AS ORDER_ID ,orderline.ProductID AS PRODUCT_ID,Products.ProductName AS PRODUCT_NAME,orderline.OrderLineID,orderline.Quantity as [Quantity]
                             from customers
                             inner join orders
                             on customers.CustomerID = Orders.custId
                             inner join orderline
                             on orders.orderId = orderline.OrderID
                             inner join Products
                             on orderline.ProductID = Products.Id
                             where orders.orderId = '" + orderNumber + "' and customers.CustomerID = '" + customerNumber + "' and orders.active = 'True'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(order);
            da.Dispose();
            con.Close();

            return order;
        }

        public ReturnDTO getLastReocrd()//last customer
        {
            ReturnDTO returns = null;
            con.Open();
            String selectCustomer = "SELECT TOP 1 * FROM  returns Order by returnID DESC ";
            SqlCommand myComm = new SqlCommand(selectCustomer, con);
            SqlDataReader myDR;
            myDR = myComm.ExecuteReader();
            if (myDR.Read())
                returns = makeEmployeeDTO(myDR);
            con.Close();
            return returns;
        }

        public ReturnDTO makeEmployeeDTO(SqlDataReader myDR)
        {

            ReturnDTO returns = new ReturnDTO.ReturnBuilder()
                                            .customerNumber(myDR.GetInt32(2))
                                            .orderNumber(myDR.GetInt32(1))
                                            .productNumber(myDR.GetInt32(3))
                                            .productQuantity(myDR.GetInt32(5))
                                            .build();
            return returns;
        }
    }
}
