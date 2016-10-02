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
    public UserDTO getUser(string username, string password)
    {
        con.Open();
        var found =new UserDTO();
        UserFacade userFacade = new UserFacade();

        string checkTechnician = "SELECT * FROM Users a INNER JOIN UserType b ON a.userTypeId = b.userTypeId where userName='" + username + "' ";
        //string checkTechnician = "SELECT * FROM user_types";
        SqlCommand cmd = new SqlCommand(checkTechnician, con);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {

            found = makeDTO(reader);
             
        }
        else
        {
            found = null; 
            
        }
         con.Close();
         return found;
       
        
    }
    public bool addUser(UserDTO model)
    {

         
            con.Open();
            string insertQuery
            = "INSERT INTO Users (userName,pass,userTypeId) VALUES (@username,@pass,@userTypeId)";
            SqlCommand cmd = new SqlCommand(insertQuery, con);
            cmd.Parameters.AddWithValue("@username", model.username);
            //cmd.Parameters.AddWithValue("@name",FullName.Text);
            cmd.Parameters.AddWithValue("@pass", model.password);
            cmd.Parameters.AddWithValue("@userType", model.userType);


            cmd.ExecuteNonQuery();
            if (cmd.ExecuteNonQuery()>0)
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
            

 



            

         
         
    }
    //public bool UpdateUser(UserDTO model);
   // public UserDTO Delete(int id);
    public UserDTO makeDTO(SqlDataReader reader)
    {
        UserDTO user = new UserDTO();
        UserTypeDTO usertypeDto = new UserTypeDTO();
        UserDAO userDao = new UserDAO();
       // SqlDataReader reader = userDao.getUser(name, username);

        user.Id = reader.GetInt32(0);
        user.username = reader.GetString(1);
        user.password = reader.GetString(2);
        //
        usertypeDto.Id = reader.GetInt32(3);
        usertypeDto.name = reader.GetString(5);
        user.userTypeDto = usertypeDto;
        return user;
    }
    
   
}