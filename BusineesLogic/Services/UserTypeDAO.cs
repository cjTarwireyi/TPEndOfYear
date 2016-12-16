using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using BusineesLogic.repositories.Impl;
/// <summary>
/// Summary description for UserTypeDAO
/// </summary>
public class UserTypeDAO
{
    private UserTypeRepositoryImpl repo = new UserTypeRepositoryImpl();
    public UserTypeDAO() { }
    public List<ListItem> getUserTypes()
    {
        return repo.getUserTypes();
    }
}