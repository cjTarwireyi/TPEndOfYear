using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System;
using BusineesLogic.Interface;
/// <summary>
/// Summary description for Service
/// </summary>
public class UserDAO:IUser
{
    private SqlConnection con;
    private UserDTO user = new UserDTO();
    private UserTypeDTO usertypeDto = new UserTypeDTO();
    public UserDAO()
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminBookingConnectionString"].ConnectionString);
         
    }
    public List<UserDTO> getUsers()
    {
        return null;
    }
    public UserDTO getUser(string username, string password)
    {
        var found = new UserDTO();
        con.Open();
        UserFacade userFacade = new UserFacade();
        string userQuerry = "SELECT * FROM Users a INNER JOIN UserType b ON a.userTypeId = b.userTypeId where userName='" + username + "' AND pass ='" + password + "'";
        SqlCommand cmd = new SqlCommand(userQuerry, con);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {

            found = makeDTO(reader);

        }

        con.Close();
        return found;
    }

    public bool ifUserExist(string username)
    {
        con.Open();
        bool found;
        UserFacade userFacade = new UserFacade();
        string checkTechnician = "SELECT * FROM Users  where userName = '" + username + "' ";
        SqlCommand cmd = new SqlCommand(checkTechnician, con);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {

            found = true;

        }
        else
        {
            found = false;

        }
        con.Close();
        return found;

    }
    public int getUserId(string username)
    {
        con.Open();

        int userId = 0;

        string select = "SELECT userTypeId  FROM UserType WHERE userTypeName ='" + username.Trim() + "'";
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
    public bool addUser(UserDTO model)
    {
        con.Open();
        string insertQuery = "INSERT INTO Users (userName,pass,userTypeId) VALUES (@username,@pass,@userTypeId)";
        SqlCommand cmd = new SqlCommand(insertQuery, con);
        cmd.Parameters.AddWithValue("@username", model.username);
        //cmd.Parameters.AddWithValue("@name",FullName.Text);
        cmd.Parameters.AddWithValue("@pass", model.password);
        cmd.Parameters.AddWithValue("@userTypeId", model.userType);

        int n = cmd.ExecuteNonQuery();
        if (n > 0)
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
    public bool UpdateUser(UserDTO model)
    {
        con.Open();
        string updateQuery = "Update Users Set userName= @username,pass=@pass,userTypeId = @userTypeId Where userId =@userId";
        SqlCommand cmd = new SqlCommand(updateQuery, con);
        cmd.Parameters.AddWithValue("@userId", model.Id);
        cmd.Parameters.AddWithValue("@username", model.username);

        cmd.Parameters.AddWithValue("@pass", model.password);
        cmd.Parameters.AddWithValue("@userTypeId", model.userType);
        int n = cmd.ExecuteNonQuery();
        if (n > 0)
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
    public bool Delete(int id)
    {
        con.Open();
        string deleteQuery = "DELETE FROM Users WHERE  userId ='" + id + "'";
        SqlCommand cmd = new SqlCommand(deleteQuery, con);
        int n = cmd.ExecuteNonQuery();
        if (n > 0)
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
    public UserDTO makeDTO(SqlDataReader reader)
    {
       
        // SqlDataReader reader = userDao.getUser(name, username);
        if (reader.HasRows == true)
        {
            user.Id = reader.GetInt32(0);
            user.username = reader.GetString(1);
            user.password = reader.GetString(2);
            //
            usertypeDto.Id = reader.GetInt32(3);
            usertypeDto.name = reader.GetString(5);
            user.userTypeDto = usertypeDto;
        }

        return user;
    }


}