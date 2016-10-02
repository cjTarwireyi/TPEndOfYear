using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for Service
/// </summary>
public class UserDAO
{
     SqlConnection con ;
	public UserDAO()
	{	
	 con= new SqlConnection(ConfigurationManager.ConnectionStrings["AdminBookingConnectionString"].ConnectionString);
//<<<<<<< HEAD
    // con.Open();
//=======
       
//>>>>>>> eeb918ba7fff5df47653ba169177ee8bbfa9e088
    }
    public List<UserDTO> getUsers()
    {
        return null;
    }
    public UserDTO getUser(string username, string password){
        con.Open();
        var found =new UserDTO();
        UserFacade userFacade = new UserFacade();

        string checkTechnician = "SELECT * FROM Users a INNER JOIN UserType b ON a.userTypeId = b.userTypeId where userName='" + username + "' ";
        //string checkTechnician = "SELECT * FROM user_types";
        SqlCommand cmd = new SqlCommand(checkTechnician, con);
        SqlDataReader reader = cmd.ExecuteReader();
         while(reader.Read())
        {
            
           found =userFacade.makeUser(reader);
           if (found.username.Trim()==username)
           {
               break;
           }
           else
           {
               found = null;
           }
         }
        // else
        //{
        //    con.Close();
        //    return null;
        //}
         con.Close();
         return found;
       
        
    }
    //public bool AddUser(UserDTO model);
   // public bool UpdateUser(UserDTO model);
   // public UserDTO Delete(int id);
    
   
}