using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserModel
/// </summary>
public class UserDTO
{
     
    public int Id { get; set; }
    public string username { get; set; }
    public string name { get; set; }
    public string surname { get; set; }
    public string contact { get; set; }
    public string email { get; set; }
    public string password { get; set; }   
    
    public int userType { get; set; }
    public  UserTypeDTO userTypeDto  { get ; set; }

    public class UserBuilder
    {
        string userName;
        string contact;
        string email;
        string password;
        UserTypeDTO userTypeDto;
        public UserBuilder buildUsername(string userName)
        {
            this.userName = userName;
            return this;
        }
        public UserBuilder buildPassword(string pass)
        {
            this.password = pass;
            return this;
        }
        public UserBuilder builduserType(UserTypeDTO userType)
        {
            this.userTypeDto = userType;
            return this;
        }
    }


}