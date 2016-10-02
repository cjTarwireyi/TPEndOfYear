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
    public UserDTO makeUser(SqlDataReader reader)
    {
        UserDTO user = new UserDTO();
        UserTypeDTO usertypeDto = new UserTypeDTO();

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