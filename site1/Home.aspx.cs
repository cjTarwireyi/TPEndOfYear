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
        Control control = Master.FindControl("sideNav");
        Label loginControl = (Label)Master.FindControl("loginLable");
        
        UserDTO userDto = new UserDTO();
        userDto = (UserDTO)Session["userDto"];
        
        control.Visible = false;
       // loginControl.Visible = false;
        loginControl.Text = "Logged in as " + userDto.username +"Logout";
       
      //  if (Session["Username"] != null)
       // {
         //   Label1.Text = Session["Username"].ToString();
      //  }
      //  else {
        //    Response.Redirect("LoginPage.aspx");

        //}
       
        
        if (userDto.userTypeDto.name.Trim() == "Admin")
        {
            control.Visible = true;
        }
      //  else
       // {
        //Label1.Text = Session["Username"].ToString();
        //}   
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        
        Session.RemoveAll();
        Response.Redirect("LoginPage.aspx");
    } 
}