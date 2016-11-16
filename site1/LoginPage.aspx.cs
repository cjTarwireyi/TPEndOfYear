﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Win32;


public partial class LoginPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        username.Focus();
       // Label regUser = (Label)Master.FindControl("regUser");
        //Control control = Master.FindControl("sideNav");
        //regUser.Visible = false;
        //control.Visible = false;
        UserDTO userDtoUpdate = new UserDTO();
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        if (Session.IsNewSession)
        {
        }
        else
        {
            Session.Abandon();
            Session.Clear();
        }
        /*if (!Page.IsPostBack)
        {
            RegistryKey rkey = Registry.CurrentUser.OpenSubKey(@"Control Panel\International", true);
            rkey.SetValue("sShortDate", "yyyy-MM-dd");
           

 
        }*/
    }
    protected void Submit_Click(object sender, EventArgs e)
    {


        UserFacade userFacade = new UserFacade();
        UserDTO userDto = new UserDTO();
        try
        {
            userDto = userFacade.login(username.Text, password.Text);
            if (userDto.username != null || userDto.password != null)
            {
                if ((userDto.username.Trim() == username.Text.Trim()) || (userDto.password.Trim() == password.Text.Trim()))
                {
                    Session["userDto"] = userDto;
                    Response.Redirect("../site1/Home.aspx");
                }
                else
                {
                    Label1.Text = "Wrong Log in credentials";
                }
            }
            else
            {
                Label1.Text = "Wrong Log in credentials";
            }
        }
        catch(Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.Message.ToString() + "');", true);

        }
    }
}