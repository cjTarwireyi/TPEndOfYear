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
public class Orders: InterfaceOder
{
    private SqlConnection con;
	public Orders()
	{
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminBookingConnectionString"].ConnectionString);
	}

    public bool AddOrder(OrderDTO order)
    {
        int created = 0;
        try
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Orders ([custId],[employeeId],[payed],[amount],[orderDate]) values('"+order.customerId +"','"+ order.employeeId +"','"+order.amount+"','"+order.paid+"','"+order.orderDate+"')";
            created = cmd.ExecuteNonQuery();
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