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
    private UserDTO userDtoUpdate;
    private UserDTO userDto;
    private ProductDAO products = new ProductDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        loadSession();
        accessRights();
        if (!IsPostBack)
            loadProducts();
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
        if (GridView1.SelectedIndex >= 0)
        {
            try
            {
                GridViewRow row = GridView1.SelectedRow;
                string id = row.Cells[1].Text;
                products.updateProductStatus(id, false);
                loadProducts();
            }
            catch(Exception ex)
            {
                ExceptionRedirect(ex);
            }
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
    private void loadProducts()
    {
        try
        {
            GridView1.DataSource = products.populateGrid();
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
    protected void gridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string id = GridView1.Rows[e.RowIndex].Cells[1].Text;
            products.delete(id);
            loadProducts();
        }
        catch (Exception ex)
        {
            ExceptionRedirect(ex);
        }
    }
    private void ExceptionRedirect(Exception ex)
    {
        Response.Redirect("ErrorPage.aspx?ErrorMessage=" + ex.Message.Replace('\n', ' '), false);
    }
    protected void gridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        loadProducts();
    }
    protected void gridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        loadProducts();
    }


    protected void gridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
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
            loadProducts();
        }
        catch(Exception ex)
        {
            ExceptionRedirect(ex);
        }
    }
}