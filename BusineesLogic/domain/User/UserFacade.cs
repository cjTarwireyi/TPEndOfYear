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
    UserDTO userDto = new UserDTO();
    public UserDTO login(string username, string pass)
    {
       
        return userDao.getUser(username, pass);
    }
    public int getUserId(string username)
    {
        return userDao.getUserId(username);
    }
    public bool userExist(string userName){
    return    userDao.ifUserExist(userName);

    }
    public string makeUser(string username, string pass, int userTypeId)

    {
        userDto = new UserDTO.UserBuilder()
        .buildUsername(username)
        .buildPassword(pass)
        .buldUsertypeId(userTypeId)
        .build();
        
        bool flag = userDao.addUser(userDto);
        if (flag==true){
            return "successfully Added";
        }
        else{
            return "Failed";
        }
    }
    public string updateUser(string username, string pass, int userTypeId,int id)
    {
        if (pass.Trim() == "")
        {
            UserDTO found = userDao.getUser(username, pass);
            userDto.password = found.password;
        }
        else
        {
            userDto.password = pass;
        }
        userDto.username = username;
        
        userDto.userTypeId = userTypeId;
        userDto.Id = id;
        bool flag = userDao.UpdateUser(userDto);
        if (flag == true)
        {
            return "successfully Added";
        }
        else
        {
            return "Failed";
        }
    }
    public string deleteUser(int id)
    {

        bool flag = userDao.Delete(id); ;
        if (flag == true)
        {
            return "successfully Added";
        }
        else
        {
            return "Failed";
        }
    }
         
    
}