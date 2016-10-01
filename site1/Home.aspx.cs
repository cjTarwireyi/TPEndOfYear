using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      //  if (Session["Username"] != null)
       // {
         //   Label1.Text = Session["Username"].ToString();
      //  }
      //  else {
        //    Response.Redirect("LoginPage.aspx");
        //}
        UserDTO userDto = (UserDTO)Session["userDto"];
        if (userDto.username.Trim() == "cj")
        {

        }
        else
        {
            Control control = Master.FindControl("sideNav");
            control.Visible = false;
        }
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        
        Session.RemoveAll();
        Response.Redirect("LoginPage.aspx");
    }
}