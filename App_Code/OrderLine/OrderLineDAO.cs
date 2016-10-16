using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
 
 

/// <summary>
/// Summary description for OrderLineDAO
/// </summary>
public class OrderLineDAO:InterfaceOrderLine
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
            con.Open();
            //string insertQuery = "INSERT INTO OrderLine (ProductID,OrderID,Quantity) VALUES (@ProductID,@OrderID,@Quantity)";
            //SqlCommand cmd = new SqlCommand(insertQuery, con);
            //cmd.Parameters.AddWithValue("@ProductID", model.productID);
            ////cmd.Parameters.AddWithValue("@name",FullName.Text);
            //cmd.Parameters.AddWithValue("@OrderID", model.orderId);
            //cmd.Parameters.AddWithValue("@Quantity", model.quantity);
            
            db.OrderLines.InsertAllOnSubmit(model);

            //int n = cmd.ExecuteNonQuery();
            //if (n > 0)
            //{
            //    con.Close();
            //    return true;
            //}
            //else
            //{
            //    con.Close();
            //    return false;
            //}
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

} 