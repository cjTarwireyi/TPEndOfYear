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
    public string password { get; set; }
    public string username { get; set; }
    
    public int roleId { get; set; }
     

}