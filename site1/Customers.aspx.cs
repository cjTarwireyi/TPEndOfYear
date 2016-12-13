﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_customer_Customers : System.Web.UI.Page
{
    private CustomerDAO customer = new CustomerDAO();
    private UserDTO userDtoUpdate;
    private UserDTO userDto;
    protected void Page_Load(object sender, EventArgs e)
    {
        
       // GridView1.Columns[1].Visible = false;
        session();
        accessRights();
        if(!IsPostBack)
            loadCustomers();
        
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
            Response.Redirect("PaymentSlip.aspx?Id=" + id, false);
        }
    }

    private void loadCustomers()
    {
        try
        {
            GridView1.DataSource = customer.populateGrid();
            GridView1.DataBind();
        }
        catch(Exception ex)
        {
            ExceptionRedirect(ex);
        }
    }

    private void session()
    {
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        userDto = (UserDTO)Session["userDto"];
        if (userDto == null)
            Response.Redirect("Default.aspx");
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        lblUser.Text = userDto.username;

        /*if (userDto.userTypeName.Trim() != "Admin")
            Response.Redirect("Home.aspx");*/

         //   AdminLinkPanel.Visible = false;
    }
    private void accessRights()
    {
        GridView1.AutoGenerateSelectButton = true;
        //rights code 
        GridView1.AutoGenerateDeleteButton = true;
        GridView1.AutoGenerateEditButton = true;
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string id = GridView1.Rows[e.RowIndex].Cells[1].Text;
            customer.delete(id);
            loadCustomers();
        }
        catch(Exception ex)
        {
            ExceptionRedirect(ex);
        }
    }

    private void ExceptionRedirect(Exception ex)
    {
        Response.Redirect("ErrorPage.aspx?ErrorMessage=" + ex.Message.Replace('\n', ' '), false);
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {  
        try
        {
            List<string> customerDetails = new List<string>();
            GridViewRow row = GridView1.Rows[e.RowIndex];
            string id = GridView1.Rows[e.RowIndex].Cells[1].Text;
            customerDetails.Add(((TextBox)row.Cells[2].Controls[0]).Text); //name
            customerDetails.Add(((TextBox)row.Cells[3].Controls[0]).Text); //surname
            customerDetails.Add(((TextBox)row.Cells[4].Controls[0]).Text); //cell number
            customerDetails.Add(((TextBox)row.Cells[5].Controls[0]).Text); //email
            customerDetails.Add(((TextBox)row.Cells[6].Controls[0]).Text); //streetname
            customerDetails.Add(((TextBox)row.Cells[7].Controls[0]).Text); //suburb
            customerDetails.Add(((TextBox)row.Cells[8].Controls[0]).Text); //postal code
            customer.update(id,customerDetails);

            GridView1.EditIndex = -1;
            loadCustomers();
        }
        catch (Exception ex)
        {
            ExceptionRedirect(ex);
        }
    }


    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        loadCustomers();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        loadCustomers();
    }
    protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
       
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        loadCustomers();
    }
}