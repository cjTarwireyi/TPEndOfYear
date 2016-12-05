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

public partial class site1_Roles : System.Web.UI.Page
{
    private DataTable table;
    private IRoleService service = new RoleDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
       

       
        
        if (!this.IsPostBack)
        {
             
            table = new DataTable();
            MakeTable();
            GridView1.DataSource = "";
            GridView1.DataBind();

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
 
        List<RoleDTO> roles;
        roles = service.getAllRoles();

        foreach (RoleDTO role in roles)
        {
            DataRow dr = table.NewRow();
            dr["RoleTitle"] = role.roleName;
            dr["Description"] = role.roleDescription;
            table.Rows.Add(dr);
        }

        // AddToDataTable();
        BindGrid();
    }

}