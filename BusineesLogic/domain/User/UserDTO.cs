﻿using System;
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
     

}