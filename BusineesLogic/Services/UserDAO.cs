using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System;
using BusineesLogic.Interface;
using System.Data;
using BusineesLogic.repositories.Impl;
/// <summary>
/// Summary description for Service
/// </summary>
public class UserDAO : IUser
{
    private UserRepositoryImp repo = new UserRepositoryImp();

    public UserDAO() { }
    public List<UserDTO> getUsers()
    {
        return repo.getUsers();
    }
    public UserDTO getUser(string username, string password)
    {
        return repo.getUser(username, password);
    }

    public bool ifUserExist(string username)
    {
        return repo.ifUserExist(username);
    }
    public int getUserTypeId(string username)
    {
        return repo.getUserTypeId(username);
    }
    public bool addUser(UserDTO model)
    {
        return repo.addUser(model);
    }
    public bool UpdateUser(UserDTO model)
    {
        return repo.UpdateUser(model);
    }
    public bool Delete(int id)
    {
        return repo.Delete(id);
    }

    public DataTable getLoginDetails(int id)
    {
        return repo.getLoginDetails(id);
    }
}