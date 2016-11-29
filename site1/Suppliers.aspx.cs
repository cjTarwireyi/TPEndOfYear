﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_Suppliers : System.Web.UI.Page
{
    private UserDTO userDto;
    private UserDTO userDtoUpdate;
    private SupplierDAO supplier = new SupplierDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        loadSession();
        accessRights();
        if(!IsPostBack)
            loadSuppliers();
    }
    protected void Register_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddSupplier.aspx");
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Response.Redirect("LoginPage.aspx");
    } 
    private void loadSession(){
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        userDto = (UserDTO)Session["userDto"];
        if (userDto == null)
            Response.Redirect("LoginPage.aspx");
        lblUser.Text = userDto.username;
    }

    private void loadSuppliers()
    {
        GridView1.DataSource = supplier.populateGrid();
        GridView1.DataBind();
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
            supplier.delete(id);
            loadSuppliers();
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
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        loadSuppliers();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        loadSuppliers();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        List<string> supplierDetails = new List<string>();
        GridViewRow row = GridView1.Rows[e.RowIndex];
        string id = GridView1.Rows[e.RowIndex].Cells[1].Text;

        supplierDetails.Add(((TextBox)row.Cells[2].Controls[0]).Text); //name
        supplierDetails.Add(((TextBox)row.Cells[3].Controls[0]).Text); //surname
        supplierDetails.Add(((TextBox)row.Cells[4].Controls[0]).Text); //cellnumber 
        supplierDetails.Add(((TextBox)row.Cells[5].Controls[0]).Text); //streetName
        supplierDetails.Add(((TextBox)row.Cells[6].Controls[0]).Text); //suburb
        supplierDetails.Add(((TextBox)row.Cells[7].Controls[0]).Text); //postal code
        
        supplier.update(id,supplierDetails);
        GridView1.EditIndex = -1;
        loadSuppliers();
    }
}