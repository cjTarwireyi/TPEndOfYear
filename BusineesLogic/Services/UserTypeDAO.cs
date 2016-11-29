using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
/// <summary>
/// Summary description for UserTypeDAO
/// </summary>
public class UserTypeDAO
{
  private  SqlConnection con ;
	public UserTypeDAO()
	{
		 
	 	
	 con= new SqlConnection(ConfigurationManager.ConnectionStrings["AdminBookingConnectionString"].ConnectionString);
 
    }
    public List<ListItem> getUserTypes()
    {
        con.Open();
 
         
        List<ListItem> items = new List<ListItem>();
       // int count = 0;

        string userTypeQuerry = "SELECT userTypeName  FROM UserType  ";
         
        SqlCommand cmd = new SqlCommand(userTypeQuerry, con);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
 
            items.Add(new ListItem(reader.GetString(0)));
            
        }
         
        con.Close();
        return items;
       

    }


}