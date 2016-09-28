using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_Books : System.Web.UI.Page
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
    protected void Submit_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Response.Redirect("../LoginPage.aspx");
    }
}