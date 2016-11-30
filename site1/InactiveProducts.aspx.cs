﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_InactiveProducts : System.Web.UI.Page
{
    private UserDTO userDtoUpdate;
    private UserDTO userDto;
    private ProductDAO products = new ProductDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        loadSession();
        accessRights();
        if(!IsPostBack)
            loadInactiveProducts();
    }
    protected void Active_Click(object sender, EventArgs e)
    {
        if (GridView1.SelectedIndex >= 0)
        {
            try
            {
                GridViewRow row = GridView1.SelectedRow;
                string id = row.Cells[1].Text;
                products.updateProductStatus(id, true);
                loadInactiveProducts();
            }
            catch(Exception ex)
            {
                ExceptionRedirect(ex);
            }
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
        try
        {
            GridView1.DataSource = products.populateInactiveProducts();
            GridView1.DataBind();
        }
        catch(Exception ex)
        {
            ExceptionRedirect(ex);
        }
    }

    private void accessRights()
    {
        GridView1.AutoGenerateSelectButton = true;
        //rights code 
        GridView1.AutoGenerateDeleteButton = true;
        GridView1.AutoGenerateEditButton = true;
    }

    private void ExceptionRedirect(Exception ex)
    {
        Response.Redirect("ErrorPage.aspx?ErrorMessage=" + ex.Message.Replace('\n', ' '), false);
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            List<string> productsDetails = new List<string>();
            GridViewRow row = GridView1.Rows[e.RowIndex];
            string id = GridView1.Rows[e.RowIndex].Cells[1].Text;

            productsDetails.Add(((TextBox)row.Cells[2].Controls[0]).Text); //name
            productsDetails.Add(((TextBox)row.Cells[3].Controls[0]).Text); //description
            productsDetails.Add(((TextBox)row.Cells[4].Controls[0]).Text); //price 
            productsDetails.Add(((TextBox)row.Cells[5].Controls[0]).Text); //quantity
            productsDetails.Add(((TextBox)row.Cells[7].Controls[0]).Text); //supplierID
            products.update(id, productsDetails);

            GridView1.EditIndex = -1;
            loadInactiveProducts();
        }
        catch (Exception ex)
        {
            ExceptionRedirect(ex);
        }
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        loadInactiveProducts();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        loadInactiveProducts();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string id = GridView1.Rows[e.RowIndex].Cells[1].Text;
            products.delete(id);
            loadInactiveProducts();
        }
        catch (Exception ex)
        {
            ExceptionRedirect(ex);
        }
    }
}