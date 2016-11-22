﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_InactiveProducts : System.Web.UI.Page
{
    private UserDTO userDto = new UserDTO();
    private UserDTO userDtoUpdate = new UserDTO();
    private ProductDAO products = new ProductDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        loadSession();
        accessRights();
        loadInactiveProducts();
    }
    protected void Active_Click(object sender, EventArgs e)
    {
        if (GridView1.SelectedIndex >= 0)
        {
            GridViewRow row = GridView1.SelectedRow;
            string id = row.Cells[1].Text;
            ProductDAO prodConnnection = new ProductDAO();
            SqlConnection con = prodConnnection.connection();
            con.Open();
            String activeProduct = "update Products set Active ='True' where Id ='"+Convert.ToInt32(id)+"'";
            SqlCommand cmd = new SqlCommand(activeProduct, con);
            cmd.ExecuteNonQuery();

            loadInactiveProducts();
            //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('"+id+"');", true);
        }
    }
    protected void btnProducts_Click(object sender, EventArgs e)
    {
        Response.Redirect("Products.aspx");
    }

    private void loadSession()
    {
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        userDto = (UserDTO)Session["userDto"];
        if (userDto == null)
            Response.Redirect("LoginPage.aspx");
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        //lblUser.Text = userDto.username;

    }

    private void loadInactiveProducts()
    {
        GridView1.DataSource = products.populateInactiveProducts();
        GridView1.DataBind();
    }

    private void accessRights()
    {
        GridView1.AutoGenerateSelectButton = true;
        //rights code 
        GridView1.AutoGenerateDeleteButton = true;
        GridView1.AutoGenerateEditButton = true;
    }
}