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

        string select = "SELECT orderId  FROM Oders WHERE orderCode ='" + orderCode.Trim() + "'";
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
         
        try
        {
            con.Open();

            string insertQuery = "INSERT INTO Oders (custId,payed,amount,orderDate,employeeId,orderCode) VALUES (@custId,@payed,@amount,@orderDate,@employeeId,@orderCode)";
            SqlCommand cmd = new SqlCommand(insertQuery, con);
            cmd.Parameters.AddWithValue("@custId", order.customerId);
            cmd.Parameters.AddWithValue("@payed",order.payed);
            cmd.Parameters.AddWithValue("@amount", order.amount);
            cmd.Parameters.AddWithValue("@orderDate", Datetime);
            cmd.Parameters.AddWithValue("@employeeId", order.employeeId);
            cmd.Parameters.AddWithValue("@orderCode", orderCode.Trim());
            int n = cmd.ExecuteNonQuery();
            
            con.Close();
            int orderId = getOrder(orderCode);
            return orderId;
           
        }
        catch (Exception e)
        {
            return 0;
        }
        finally
        {
            con.Close();
             
        }

         
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