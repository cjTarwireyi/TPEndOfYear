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
public class OrdersDAO: InterfaceOder
{
    private SqlConnection con;
    DataClassesDataContext db = new DataClassesDataContext();
    public OrdersDAO()
	{
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminBookingConnectionString"].ConnectionString);
	}
    public int AddOrder(OrderDTO model)
    {
        try
        {
            Order order = new Order();
            var time = DateTime.Now;
            var orderCode = model.customerId + "-" + time;
            order.custId = model.customerId;
            order.employeeId = model.employeeId;
            order.amount = model.amount;
            order.payed = model.payed;
            order.orderDate = time;
            order.orderCode = orderCode;
            db.Orders.InsertOnSubmit(order);
            Order orderfound = db.Orders.Where(t => t.orderCode == orderCode).Single();
            return orderfound.orderId;
        }
        catch (Exception e)
        {
            e.GetBaseException();
            return new Int32();

        }
    }

    //public int AddOrder(OrderDTO order)
    //{
    //    int created = 0;
    //    try
    //    {
    //        con.Open();
    //        SqlCommand cmd = con.CreateCommand();
    //        cmd.CommandType = CommandType.Text;
    //        cmd.CommandText = "insert into Orders ([custId],[employeeId],[payed],[amount],[orderDate]) values('"+order.customerId +"','"+ order.employeeId +"','"+order.amount+"','"+order.payed+"','"+order.orderDate+"')";
    //        created = cmd.ExecuteNonQuery();
    //        con.Close();
    //    }
    //    catch (Exception e)
    //    {

    //    }
    //    finally
    //    {
    //        con.Close();
    //    }

    //    if (created == 1)
    //        return true;
    //    else
    //        return false;
    //}
  public  bool UpdateOrder(OrderDTO model)
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
            cmd.CommandText = "delete from OrderLine where OrderID = '"+orderId+"'";
            cmd.ExecuteNonQuery();

            //delete from Orders
            cmd.CommandText = "delete from Orders where OrderID = '"+orderId+"'";
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
}