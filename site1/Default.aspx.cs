using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Win32;
using System.Threading;


public partial class LoginPage : System.Web.UI.Page
{
    private UserFacade userFacade = new UserFacade();
    private UserDTO userDto ;
    protected void Page_Load(object sender, EventArgs e)
    {
        loginSession();
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        userDto = new UserDTO();
        try
        {
            userDto = userFacade.login(txtUsername.Text, txtPassword.Text);
            if (userDto.username != null || userDto.password != null)
            {
                if ((userDto.username.Trim() == txtUsername.Text.Trim()) || (userDto.password.Trim() == txtPassword.Text.Trim()))
                {
                    Session["userDto"] = userDto;
                    Response.Redirect("Home.aspx");
                }
                else
                    Label1.Text = "Wrong Log in credentials";
            }
            else
                Label1.Text = "Wrong Log in credentials";
        }
        catch (SqlException ex)
        {
            ExceptionRedirect(ex);
        }
    }

    private void ExceptionRedirect(Exception ex)
    {
        Response.Redirect("ErrorPage.aspx?ErrorMessage=" + ex.Message.Replace('\n', ' '), false);
    }

    private void loginSession()
    {
        txtUsername.Focus();
        UserDTO userDtoUpdate = new UserDTO();
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        if (Session.IsNewSession)
        {
        }
        else
        {
           // Session.Abandon();
            //Session.Clear();
        }

    }
}