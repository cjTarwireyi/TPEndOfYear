using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusineesLogic.Interface;
using System.Data;
using BusineesLogic.domain;
using BusineesLogic.factories;

public partial class TimeSheet : System.Web.UI.Page
{
    private DataTable empDataTable;
    private UserDTO userDto;
    private UserDTO userDtoUpdate;
    private EmployeeDAO service = new EmployeeDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        session();
            empDataTable = new DataTable();
            empDataTable = service.getEmpComboboxData();


            empList.DataSource = empDataTable;
            empList.DataValueField = "EmployeeID";
            empList.DataTextField = "empName";
            // custList.Col = "CustomerSurname" +"  CustomerName" ;
            empList.DataBind();
            empList.SelectedIndex = -1;
    }
    protected void Submit_Click(object sender, EventArgs e)
    { }
    protected void Cancel_Click(object sender, EventArgs e)
    { }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        TimeSheetDTO timesheeetDto; 
         
        string name = Request.Form["tdate"];
        
        
       string dt = this.Request.Form.Get("tdate");
       DateTime date = DateTime.Parse(dt);
       String timeIn = this.Request.Form.Get("timein");
       String timeOut = this.Request.Form.Get("timeout");
    //   timesheeetDto = TimeSheetFactory.createTimeSheet(Convert.ToInt32(empList.SelectedItem.Value), date, timeIn, timeOut, txtComents.Text);
       

         
        
        
        
        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Numbers Only!!!');", true);
        //table = new DataTable();
       // MakeTable();


       // LoadGridHelper();
        //txtRole.Text = string.Empty;
        //txtDescription.Text = string.Empty;


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
        //role = new RoleDTO.RoleBuilder()
        //.buildRoleID(Convert.ToInt32(roleId))
        //.buildRoleName(roleName)
        //.buildroleDescription(desc)
        //.build();

       // service.updateRole(role);
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
           // service.deleteRole(roleId);
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
        //table.Columns.Add("roleId");
        //table.Columns.Add("RoleName");
        //table.Columns.Add("RoleDescription");

    }
    private void BindGrid()
    {
        GridView1.DataSource = "";// table;
        GridView1.DataBind();
    }
    private void AppendLastRecordGrid()
    {
        //RoleDTO role = service.getLastReocrd();
        //DataRow dr = table.NewRow();
        //dr["roleId"] = role.roleId;
        //dr["RoleName"] = role.roleName;
        //dr["RoleDescription"] = role.roleDescription;
        //table.Rows.Add(dr);


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
            GridView1.DataSource="";
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


        // AdminLinkPanel.Visible = false;
        if (userDto.userTypeName.Trim() != "Admin")
        {
            Response.Redirect("Home.aspx");
            AdminLinkPanel.Visible = false;
        }
        else
            userPanel.Visible = false;
    }

}