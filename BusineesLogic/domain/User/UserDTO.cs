using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserModel
/// </summary>
public class UserDTO
{
     public UserDTO(UserBuilder userBuilder)
     {
         this.username = userBuilder.userName;
         this.password = userBuilder.password;
         this.userTypeDto = userBuilder.userTypeDto;
     }
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
        public string userName;
        public string contact;
        public string email;
        public string password;
        public UserTypeDTO userTypeDto;
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
        public UserBuilder copy(UserDTO user)
        {
            this.userName=user.username;
            this.password = user.password;
            this.userTypeDto = user.userTypeDto;
            return this;
                
        }
        public UserDTO build()
        {
            return new UserDTO(this);
        }
    }


        
    }


