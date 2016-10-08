using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
  private  UserDTO userDto = new UserDTO();
    protected void Page_Load(object sender, EventArgs e)   {
       
        
        
        userDto = (UserDTO)Session["userDto"];
        if (userDto == null)        
        Response.Redirect("LoginPage.aspx");
        Control control = Master.FindControl("sideNav");
        Label loginControl = (Label)Master.FindControl("loginLable");
        Label regUser = (Label)Master.FindControl("regUser");
        
        control.Visible = false;
        regUser.Visible = false;
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
            regUser.Visible = true;
        }
      //  else
       // {
        //Label1.Text = Session["Username"].ToString();
        //}   
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        
        Session.Abandon();
        Session.Clear();
       // userDto.
        Response.Redirect("LoginPage.aspx");
    } 
}