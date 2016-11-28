using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System;



/// <summary>
/// Summary description for OrderLineDAO
/// </summary>
public class OrderLineDAO : InterfaceOrderLine
{
    SqlConnection con;

    public OrderLineDAO()
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminBookingConnectionString"].ConnectionString);

    }
    public bool AddOderLine(List<OrderLineDTO> model)
    {
        //int n;
        con.Open();
        foreach (var rec in model)
        {
            string insertQuery = "INSERT INTO OrderLine (ProductID,OrderID,Quantity) VALUES ('" + rec.productID + "','" + rec.orderId + "','" + rec.quantity + "')";
            SqlCommand cmd = new SqlCommand(insertQuery, con);
            /*cmd.Parameters.Add("@ProductID",rec.ProductID);
            //cmd.Parameters.AddWithValue("@name",FullName.Text);
            cmd.Parameters.AddWithValue("@OrderID", rec.OrderID);
            cmd.Parameters.AddWithValue("@Quantity", rec.Quantity);*/
            cmd.ExecuteNonQuery();
        }

        con.Close();
        return true;
    }
    public bool RemoveProduct(OrderLineDTO model)
    {
        return true;
    }
    public bool UpdateOrderLine(OrderLineDTO model)
    {
        return true;
    }

    public List<OrderLineDTO> getOrderItems(int orderID)
    {
        var items = new List<OrderLineDTO>();
        con.Open();
        string selectItems = "select * from OrderLine where OrderID=" + orderID + "";
        SqlCommand myComm = new SqlCommand(selectItems, con);
        SqlDataReader myDR;
        myDR = myComm.ExecuteReader();
        while (myDR.Read())
        {
            OrderLineDTO order = new OrderLineDTO();
            order.orderLineID = myDR.GetInt32(0);
            order.productID = myDR.GetInt32(1);
            order.quantity = myDR.GetInt32(2);
            order.orderId = myDR.GetInt32(3);

            items.Add(order);
        }
        con.Close();
        return items;
    }

    public void updateInsertOrder(string orderID, string productID, string quantity)
    {

        con.Open();
        string insertQuery = "insert into orderline (ProductID,OrderID,Quantity) values ('" + productID + "','" + orderID + "','" + quantity + "')";
        SqlCommand cmd = new SqlCommand(insertQuery, con);
        cmd.ExecuteNonQuery();
        con.Close();
    }

    public void removeItem(string id, string orderline)
    {
        updateQuantity(id, orderline);

        con.Open();
        string query = "delete from OrderLine where OrderLineID ='" + id + "' ";
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public void updateQuantity(string productID, string orderlineID)
    {
        string productQuantity = "";
        int newQuantity;
        string returnQuantity = "";
        DataTable orders = new DataTable();
        DataTable orderline = new DataTable();

        con.Open();
        string getQuantity = "select quantity from products where id ='" + productID + "' ";
        SqlCommand cmd = new SqlCommand(getQuantity, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(orders);
        da.Dispose();
        foreach (DataRow row in orders.Rows)
        {
            productQuantity = row["Quantity"].ToString();
        }
        //cmd.ExecuteNonQuery();

        string returnQuery = "select quantity from orderline where OrderlineID = '" + orderlineID + "'";
        cmd = new SqlCommand(returnQuery, con);
        da = new SqlDataAdapter(cmd);
        da.Fill(orderline);
        da.Dispose();
        foreach (DataRow row in orderline.Rows)
        {
            returnQuantity = row["Quantity"].ToString();
        }
        //cmd.ExecuteNonQuery();
        newQuantity = Convert.ToInt32(productQuantity) + Convert.ToInt32(returnQuantity);

        string query = "update products set Quantity ='" + newQuantity + "' where id = '" + productID + "' ";
        cmd = new SqlCommand(query, con);
        cmd.ExecuteNonQuery();
        con.Close();
    }
}