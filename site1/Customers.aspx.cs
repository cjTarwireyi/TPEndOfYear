﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_customer_Customers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // GridView1.Columns[1].Visible = false;
        UserDTO userDtoUpdate = new UserDTO();
        UserDTO userDto= new UserDTO();
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        userDto = (UserDTO)Session["userDto"];
        if (userDto == null)
            Response.Redirect("LoginPage.aspx");
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        lblUser.Text = userDto.username;
        
        
    }
    protected void Register_Click(object sender, EventArgs e)
    {
       
        Response.Redirect("AddCustomer.aspx");
    }
    protected void Submit_Click(object sender, EventArgs e)
    {

        Session.Abandon();
        Session.Clear();

        Response.Redirect("LoginPage.aspx");
    }


    protected void btnPrint_Click(object sender, EventArgs e)
    {
        if (GridView1.SelectedIndex >= 0)
        {
            GridViewRow row = GridView1.SelectedRow;
            string id = row.Cells[1].Text;
            //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('"+id+"');", true);
            Response.Redirect("PaymentSlip.aspx?Id=" + id, false);
        }
            
    }
}