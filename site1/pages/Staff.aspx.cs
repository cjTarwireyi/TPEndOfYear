using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_Staff : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] != null)
        {
            Label1.Text = Session["Username"].ToString();
        }
        else
        {
            Response.Redirect("../LoginPage.aspx");
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow) {

            LinkButton lb = (LinkButton)e.Row.FindControl("LinkButton1");
            lb.Attributes.Add("onclick", "return confirm('Are you sure to delete');");
        }
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Response.Redirect("../LoginPage.aspx");
    }
}