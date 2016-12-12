using BusineesLogic.domain;
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
    private SqlConnection con;
    private ProductDAO productService = new ProductDAO();
    private ReturnDTO itemReturned;
    private ReturnDAO returnService = new ReturnDAO();

    public OrdersDAO()
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminBookingConnectionString"].ConnectionString);
    }
     
    private int getOrder(string orderCode)
    {

        con.Open();
        int userId = 0;
        string select = "SELECT orderId  FROM Orders WHERE orderCode ='" + orderCode.Trim() + "'";
        //string checkTechnician = "SELECT * FROM user_types";
        SqlCommand cmd = new SqlCommand(select, con);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            userId = reader.GetInt32(0);
        }
        con.Close();
        return userId;


    }

    public int AddOrder(OrderDTO order)
    {
        int created = 0;
        var Datetime = DateTime.Now;
        var orderCode = order.customerId + "-" + Datetime.Ticks.ToString();

        
        con.Open();
        string insertQuery = "INSERT INTO Orders (custId,payed,amount,orderDate,employeeId,orderCode,active) VALUES ('" + order.customerId + "','" + order.payed + "','" + order.amount + "','" + DateTime.Now.ToString() + "','" + order.employeeId + "','" + orderCode.Trim() + "','True')";
        SqlCommand cmd = new SqlCommand(insertQuery, con);
        cmd.ExecuteNonQuery();

        con.Close();
        int orderId = getOrder(orderCode);
        return orderId;
    }
    public bool UpdateOrder(OrderDTO model)
    {
        return true;
    }
    public bool deleteOrder(int orderId)
    {

        int created = 0;
        try
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //delete from OrderLine
            cmd.CommandText = "delete from OrderLine where OrderID = '" + orderId + "'";
            cmd.ExecuteNonQuery();

            //delete from Orders
            cmd.CommandText = "delete from Orders where OrderID = '" + orderId + "'";
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

        if (created == 1)
            return true;
        else
            return false;
    }

    public OrderDTO makeOrderDTO(SqlDataReader myDR)
    {
         OrderDTO order = order = new OrderDTO.OrderBuilder()
        .buildorderId(myDR.GetInt32(0))
        .buildCustId(myDR.GetInt32(1))
        .buildPayed(myDR.GetBoolean(2))
        .buildAmount(myDR.GetDecimal(3))
        .buildOrderDate(myDR.GetDateTime(4))
        .buildEmpId(myDR.GetInt32(5))
        .build();
        //ordercode missing 
        //booking.Hours = myDR.GetInt32(8);
        return order;
    }

    public OrderDTO getLastReocrd()
    {
        OrderDTO order = new OrderDTO();
        con.Open();
        String selectCustomer = "SELECT TOP 1 * FROM  Orders Order by orderid DESC ";
        SqlCommand myComm = new SqlCommand(selectCustomer, con);
        SqlDataReader myDR;
        myDR = myComm.ExecuteReader();
        if (myDR.Read())
            order = makeOrderDTO(myDR);
        con.Close();
        return order;
    }


    public OrderDTO getOrder(int id)
    {
        OrderDTO order = new OrderDTO();
        con.Open();
        String selectCustomer = "select * from Orders where orderId =" + id + " and active = 'True' ";
        SqlCommand myComm = new SqlCommand(selectCustomer, con);
        SqlDataReader myDR;
        myDR = myComm.ExecuteReader();
        if (!myDR.Read())
            return null;
        order = makeOrderDTO(myDR);
        con.Close();
        return order;
    }

    public DataTable getOrdersDetails(DataTable productsOrdered, int orderID)
    {

        string query = @"select orders.orderId,Products.id,Products.productName
                        from orders
                        inner join OrderLine on orders.orderId = orderline.OrderID
                        inner join Products on  orderline.ProductID = Products.id 
                        where orderline.OrderID = '" + orderID + "'order by orders.orderId ";

        SqlCommand cmd = new SqlCommand(query, con);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(productsOrdered);
        da.Dispose();
        con.Close();
        return productsOrdered;
    }

    public DataTable searchOrder(DataTable orderRecord, string id, bool status)
    {

        string query = @"select orderid,custid,payed,amount,orderDate,employeeid,orderCode from Orders where orderid = '" + id + "' and payed = '" + status + "' and active = 'True' ";
        SqlCommand cmd = new SqlCommand(query, con);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(orderRecord);
        da.Dispose();
        con.Close();
        return orderRecord;
    }
    public DataTable searchGrid(DataTable orders, string date, bool payed)
    {
        string year = date.Substring(0, 4);
        string month = date.Substring(5, 1);
        string query = "select * from Orders where SUBSTRING (CONVERT(nvarchar(10),orderDate,112),6,2) = '" + month + "' and SUBSTRING (CONVERT(nvarchar(10),orderDate,112),1,4) = '" + year + "' and payed = '" + payed + "' and active='True'";
        con.Open();
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(orders);
        da.Dispose();
        con.Close();
        return orders;
    }


    public DataTable populateGrid(string month, string year, bool status)
    {
        DataTable orders = new DataTable();
        string query = "select * from Orders where SUBSTRING (CONVERT(nvarchar(10),orderDate,112),5,2) = '" + month + "' and SUBSTRING (CONVERT(nvarchar(10),orderDate,112),1,4) = '" + year + "' and payed ='" + status + "' and active = 'True' ";
        con.Open();
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(orders);
        da.Dispose();
        con.Close();
        return orders;
    }


    public void calculateOrder(string orderID,string customerID)
    {

        calculate(orderID,customerID); 
    }


    private  DataTable getOrderItem(string orderID,string customerID)
    {
        DataTable itemPrices = new DataTable();
        string query = @"select orderline.Quantity,Products.Price
                        from products
                        inner join orderline
                        on products.Id = orderline.ProductID
                        inner join orders
                        on OrderLine.OrderID = Orders.orderId
                        inner join Customers
                        on Orders.custId = Customers.CustomerID
                        where orderline.OrderID = '"+orderID+"' and Customers.CustomerID = '"+customerID+"' and orders.active='True' order by orderline.OrderID";
        con.Open();
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(itemPrices);
        da.Dispose();
        con.Close();
        return itemPrices;
    }


    private void calculate(string id,string customerID)
    {
        int total = 0;
        DataTable dt = getOrderItem(id,customerID);
        foreach(DataRow row in dt.Rows)
        {
            total = total + (Convert.ToInt32(row["Quantity"].ToString()) * Convert.ToInt32(row["Price"].ToString()));
        }
        updateAmount(id,total);
    }


    public void updateAmount(string id,int amount)
    {
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "update orders set amount ='" + amount.ToString() + "' where orderid = '" + id + "' ";
        cmd.ExecuteNonQuery();
        con.Close();
    }

    public void paid(string id)
    {
        bool paid = true;
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "update orders set payed ='" + paid+ "' where orderid = '" + id + "' ";
        cmd.ExecuteNonQuery();
        con.Close();
    }


    public void cancelOrder(string orderNo)
    {
        DataTable dtOrder = new DataTable();
        dtOrder = getOrderLine(orderNo);
        foreach(DataRow row in dtOrder.Rows)
        {
            string productID = row["ProductID"].ToString();
            string quantity = row["Quantity"].ToString();
            string orderID = row["OrderID"].ToString();
            
            //update quantity
            productService.itemBought(productID,quantity,"+");

            //builder objcet
             itemReturned = new ReturnDTO.ReturnBuilder()
            .customerNumber(Convert.ToInt32(2))
            .orderNumber(Convert.ToInt32(orderID))
            .productNumber(Convert.ToInt32(productID))
            .build();

             //insert into return item
             returnService.save(itemReturned);
        }
        cancel(orderNo);
    }

    private DataTable getOrderLine(string orderNo)
    {
        DataTable orders = new DataTable();
        string query = "select * from orderline where OrderID = '"+orderNo+"' ";
        con.Open();
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(orders);
        da.Dispose();
        con.Close();
        return orders;
    }

    private void cancel(string id)
    {
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "update orders set active = 'False' where orderid = '" + id + "' ";
        cmd.ExecuteNonQuery();
        con.Close();
    }
}