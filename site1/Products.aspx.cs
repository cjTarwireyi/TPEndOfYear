﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_Products : System.Web.UI.Page
{
    private UserDTO userDtoUpdate = new UserDTO();
    private UserDTO userDto = new UserDTO();
    private ProductDAO products = new ProductDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        loadSession();
        loadSuppliers();
    }
    protected void Register_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddProduct.aspx");
    }
    protected void InactiveRecords(object sender, EventArgs e)
    {
        Response.Redirect("InactiveProducts.aspx");
    }
    
    protected void btnDeactivate_Click(object sender, EventArgs e)
    {
        if (gridView1.SelectedIndex >= 0)
        {
            GridViewRow row = gridView1.SelectedRow;
            string id = row.Cells[1].Text;
            ProductDAO prodConnnection = new ProductDAO();
            SqlConnection con = prodConnnection.connection();
            con.Open();
            String activeProduct = "update Products set Active ='False' where Id ='" + Convert.ToInt32(id) + "'";
            SqlCommand cmd = new SqlCommand(activeProduct, con);
            cmd.ExecuteNonQuery();
            loadSuppliers();
            
            //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('"+id+"');", true);
        }
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Response.Redirect("LoginPage.aspx");
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
        lblUser.Text = userDto.username;
    }
    private void loadSuppliers()
    {
        gridView1.DataSource = products.populateGrid();
        gridView1.DataBind();
    }
}