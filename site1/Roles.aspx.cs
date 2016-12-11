﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusineesLogic.Interface;
using BusineesLogic.services;
using BusineesLogic.factories;
using System.Drawing;
using BusineesLogic.domain;

public partial class site1_Roles : System.Web.UI.Page
{
    private DataTable table;
    private IRoleService service = new RoleDAO();
    private EmailDTO email = new EmailDTO();
    private RoleDTO role;
    protected void Page_Load(object sender, EventArgs e)
    {



        accessRights(); 
        if (!this.IsPostBack) 
        {
             
            table = new DataTable();
            MakeTable();
            //GridView1.DataSource = "";
           /// GridView1.DataBind();

            LoadGridHelper();
        }
        else
            table = (DataTable)ViewState["DataTable"];
        ViewState["DataTable"] = table;
    }
    protected void Submit_Click(object sender, EventArgs e)
    { }
    protected void Cancel_Click(object sender, EventArgs e)
    { }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        RoleDTO role = RoleFactory.createRole(txtRole.Text,txtDescription.Text);
        service.addRole(role);
        AppendLastRecordGrid();
        
         
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = GridView1.Rows[e.RowIndex];
        string id = ((TextBox)row.Cells[1].Controls[0]).Text;
        string roleName = ((TextBox)row.Cells[2].Controls[0]).Text;
        string desc = ((TextBox)row.Cells[3].Controls[0]).Text;
        role = new RoleDTO.RoleBuilder()
        .buildRoleID(Convert.ToInt32(id))
        .buildRoleName(roleName)
        .buildroleDescription(desc)
        .build();
        
        service.updateRole(role);
        GridView1.EditIndex = -1;
        LoadGridHelper();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        LoadGridHelper();
        
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        LoadGridHelper();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string id = GridView1.Rows[e.RowIndex].Cells[1].Text;
            service.deleteRole(Convert.ToInt32(id));
            LoadGridHelper();
        }
        catch (Exception ex)
        {
            ExceptionRedirect(ex);
        }
    }
    protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {

    }
    protected void Logout(object sender, EventArgs e)
    {

        Session.Abandon();
        Session.Clear();
        Response.Redirect("LoginPage.aspx");
    }
    private void MakeTable()
    {
        table.Columns.Add("RoleTitle");
        table.Columns.Add("Description");
       
    }
    private void BindGrid()
    {
        GridView1.DataSource = table;
        GridView1.DataBind();
    }
    private void AppendLastRecordGrid()
    {
        RoleDTO role = service.getLastReocrd();
        DataRow dr = table.NewRow();
            dr["RoleTitle"] = role.roleName;
            dr["Description"] = role.roleDescription;
            table.Rows.Add(dr);
        

        // AddToDataTable();
        BindGrid();
    }
    private void LoadGridHelper()
    {
 
        //List<RoleDTO> roles;
        //roles = service.getAllRoles();

        //foreach (RoleDTO role in roles)
        //{
        //    DataRow dr = table.NewRow();
        //    dr["RoleTitle"] = role.roleName;
        //    dr["Description"] = role.roleDescription;
        //    table.Rows.Add(dr);
        //}

        //// AddToDataTable();
        //BindGrid();

        try
        {
            GridView1.DataSource = service.populateGrid();
            GridView1.DataBind();
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

    private void accessRights()
    {
        //GridView1.AutoGenerateSelectButton = true;
        //rights code 
        GridView1.AutoGenerateDeleteButton = true;
        GridView1.AutoGenerateEditButton = true;
    }
}