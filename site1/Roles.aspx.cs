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
    private EmailDTO email;
    private RoleDTO role;



    private UserDTO userDto;
    private UserDTO userDtoUpdate;
    protected void Page_Load(object sender, EventArgs e)
    {

        session();

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
        RoleDTO role = RoleFactory.createRole(txtRole.Text, txtDescription.Text);
        service.addRole(role);


        table = new DataTable();
        MakeTable();


        LoadGridHelper();
        txtRole.Text = string.Empty;
        txtDescription.Text = string.Empty;


    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int roleId = 0;
        GridViewRow row = GridView1.Rows[e.RowIndex];
        Label lblId = (Label)row.FindControl("lblRoleID");
        if (lblId.Text == "")
        {
            roleId = 0;
        }
        else
        {
            roleId = Convert.ToInt32(lblId.Text);
        }
        // string id = ((TextBox)row.Cells[1].Controls[0]).Text;
        string roleName = ((TextBox)row.Cells[2].Controls[0]).Text;
        string desc = ((TextBox)row.Cells[3].Controls[0]).Text;
        role = new RoleDTO.RoleBuilder()
        .buildRoleID(Convert.ToInt32(roleId))
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
            int roleId = 0;
            GridViewRow row = GridView1.Rows[e.RowIndex];
            Label lblId = (Label)row.FindControl("lblRoleID");
            if (lblId.Text == "")
            {
                roleId = 0;
            }
            else
            {
                roleId = Convert.ToInt32(lblId.Text);
            }
            service.deleteRole(roleId);
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
        Response.Redirect("Default.aspx");
    }
    private void MakeTable()
    {
        table.Columns.Add("roleId");
        table.Columns.Add("RoleName");
        table.Columns.Add("RoleDescription");

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
        dr["roleId"] = role.roleId;
        dr["RoleName"] = role.roleName;
        dr["RoleDescription"] = role.roleDescription;
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
        // GridView1.AutoGenerateSelectButton = true;
        //rights code 
        if (userDto.userTypeName.Trim() != "Admin")
        {
            GridView1.AutoGenerateDeleteButton = false;
            GridView1.AutoGenerateEditButton = false;
        }
        else
            GridView1.AutoGenerateDeleteButton = true;
        GridView1.AutoGenerateEditButton = true;
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

        if (userDto.userTypeName.Trim() != "Admin")
            AdminLinkPanel.Visible = false;
        else
            userPanel.Visible = false;

    }

}