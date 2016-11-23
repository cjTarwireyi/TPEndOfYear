using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
  
using System.Web.UI;
using System.Web.UI.WebControls;
 
using System.Configuration;
/// <summary>


/// <summary>
/// Summary description for UserTypeFacade
/// </summary>
public class UserTypeFacade
{
    private UserTypeDAO userTypeDao = new UserTypeDAO();
    private EmployeeDAO eDAo = new EmployeeDAO();
	public UserTypeFacade()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public List<ListItem> getUserTypes()
    {
         
          
        return userTypeDao.getUserTypes();  
    }
    public string  getEmployee(int id){
        string msg;
        if (eDAo.getEmployee(id) == null)
        {
            msg = "employee doesn't exist";
        }
        else
        {
            msg = "ok";
        }
        return msg;
    }
}