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

        string checkTechnician = "SELECT userTypeName  FROM UserType  ";
        //string checkTechnician = "SELECT * FROM user_types";
        SqlCommand cmd = new SqlCommand(checkTechnician, con);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

         //   found = makeDTO(reader);
            items.Add(new ListItem(reader.GetString(0)));
           // var data = reader;
        }
        //else
        //{
        //  found =makeDTO(re null; 

        //}
        con.Close();
        return items;
       

    }


}