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
    DataClassesDataContext db = new DataClassesDataContext();
    public OrderLineDAO()
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminBookingConnectionString"].ConnectionString);

    }
    public bool AddOderLine(List<OrderLine> model)
    {
        try
        {

            //int n;
            con.Open();
            foreach (var rec in model)
            {
                string insertQuery = "INSERT INTO OrderLine (ProductID,OrderID,Quantity) VALUES ('" + rec.ProductID + "','" + rec.OrderID + "','" + rec.Quantity + "')";
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
        catch (SqlException ex)
        {
            ex.GetBaseException();
            return false;
        }
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
        //try
        //{
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
        //}
        //catch (Exception ex)
        //{

        //}
        //finally
        //{
        //    con.Close();
        //}
        return items;
    }
}