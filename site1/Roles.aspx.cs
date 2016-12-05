using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusineesLogic.Interface;
using System.Drawing;

public partial class site1_Roles : System.Web.UI.Page
{
    private DataTable table;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
             
            table = new DataTable();
            MakeTable();
            GridView1.DataSource = "";
            GridView1.DataBind();
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
    { }
    protected void Logout(object sender, EventArgs e)
    {

        Session.Abandon();
        Session.Clear();
        Response.Redirect("LoginPage.aspx");
    }
    private void MakeTable()
    {
        table.Columns.Add("ProductCode");
        table.Columns.Add("Product");
        table.Columns.Add("Price");
        table.Columns.Add("Quantity");
    }

}