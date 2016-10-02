using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for UserFacade
/// </summary>
public class UserFacade
{
	public UserFacade()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    UserDAO userDao = new UserDAO();
    public UserDTO login(string username, string pass)
    {
       
        return userDao.getUser(username, pass);
    }
    public string makeUser(string username, string pass, int userTypeId)

    {
        UserDTO userDto = new UserDTO();
        //userDto.Id =  
        userDto.username =  username; 
        userDto.password = pass ;
        //
        userDto.Id = userTypeId;
        bool flag = userDao.addUser(userDto);
        if (flag==true){
            return "successfully Added";
        }
        else{
            return "Failed";
        }
    }
    
         
    
}