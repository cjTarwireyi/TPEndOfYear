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
public class OrdersDAO : InterfaceOder
{
    private SqlConnection con;
 
    public OrdersDAO()
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminBookingConnectionString"].ConnectionString);
    }
    //    //public int AddOrder(OrderDTO model)
    //    //{
    //try
    //        {
    //            Oder1 order = new Oder1();
    //            var time = DateTime.Now;
    //            var orderCode = model.customerId + "-" + time;
    //            order.custId = model.customerId;
    //            order.employeeId = model.employeeId;
    //            order.amount = model.amount;
    //            order.payed = model.payed;
    //            order.orderDate = time;
    //            order.orderCode = orderCode;
    //            db.Oder1s.InsertOnSubmit(order);
    //            Oder1 orderfound = db.Oder1s.Where(t => t.orderCode == orderCode).Single();
    //            return orderfound.orderId;
    //        }
    //       catch(Exception e) {
    //            e.GetBaseException();
    //            return new Int32();

    //        }
    //    /}

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

        //try
        //{
            con.Open();

            string insertQuery = "INSERT INTO Orders (custId,payed,amount,orderDate,employeeId,orderCode) VALUES ('" + order.customerId + "','" + order.payed + "','" + order.amount + "','" + DateTime.Now.ToString() + "','" + order.employeeId + "','"+orderCode.Trim()+"')";
            SqlCommand cmd = new SqlCommand(insertQuery, con);
          //  cmd.Parameters.AddWithValue("@custId", order.customerId);
            //cmd.Parameters.AddWithValue("@payed", order.payed);
            //cmd.Parameters.AddWithValue("@amount", order.amount);
            //cmd.Parameters.AddWithValue("@orderDate", Datetime);
            //cmd.Parameters.AddWithValue("@employeeId", order.employeeId);
            //cmd.Parameters.AddWithValue("@orderCode", orderCode.Trim());
            cmd.ExecuteNonQuery();

            con.Close();
            int orderId = getOrder(orderCode);
            return orderId;

        /*}
        catch (Exception e)
        {
            return 0;
        }
        finally
        {
            con.Close();

        }*/
    }
    public bool UpdateOrder(OrderDTO model)
    {
        return true;
    }
    public bool DeleteOrder(int orderId)
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
        OrderDTO order = new OrderDTO();
        try
        {
            order.orderId = myDR.GetInt32(0);
            order.customerId = myDR.GetInt32(1);
            order.payed = myDR.GetBoolean(2);
            order.amount = myDR.GetInt32(3);
            order.orderDate = myDR.GetDateTime(4);
            order.employeeId = myDR.GetInt32(5);
            //ordercode missing 
        }
        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
        }
        //booking.Hours = myDR.GetInt32(8);
        return order;

    }

    public OrderDTO getLastReocrd()//last customer
    {
        OrderDTO order = new OrderDTO();
        try
        {
            con.Open();
            String selectCustomer = "SELECT TOP 1 * FROM  Orders Order by orderid DESC ";
            SqlCommand myComm = new SqlCommand(selectCustomer, con);
            SqlDataReader myDR;
            myDR = myComm.ExecuteReader();
            if (myDR.Read())
                order = makeOrderDTO(myDR);
            con.Close();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
        }
        return order;
    }


    public OrderDTO getOrder(int id)
    {
        OrderDTO order = new OrderDTO();
        con.Open();
        String selectCustomer = "select * from Orders where orderId =" + id + " ";
        SqlCommand myComm = new SqlCommand(selectCustomer, con);
        SqlDataReader myDR;
        myDR = myComm.ExecuteReader();
        if (!myDR.Read())
            return null;
        order = makeOrderDTO(myDR);
        con.Close();
        return order;
    }
}