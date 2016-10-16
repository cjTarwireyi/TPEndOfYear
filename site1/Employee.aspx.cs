﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_Employee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        UserDTO userDtoUpdate = new UserDTO();
        UserDTO userDto = new UserDTO();
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        userDto = (UserDTO)Session["userDto"];
        if (userDto == null)
            Response.Redirect("LoginPage.aspx");

        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        lblUser.Text = userDto.username;
        
        

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void Register_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddEmployee.aspx");
    }
    protected void Submit_Click(object sender, EventArgs e)
    {

        Session.Abandon();
        Session.Clear();

        Response.Redirect("LoginPage.aspx");
    } 
   
}