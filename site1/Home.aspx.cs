using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
  private  UserDTO userDto = new UserDTO();
  private UserDTO userDtoUpdate = new UserDTO();
    protected void Page_Load(object sender, EventArgs e) 
    { 


        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        userDto = (UserDTO)Session["userDto"];
        if (userDto == null)        
        Response.Redirect("LoginPage.aspx");
        //Control control = Master.FindControl("sideNav");
        //Label loginControl = (Label)Master.FindControl("loginLable");
        //Label regUser = (Label)Master.FindControl("regUser");
        
        //control.Visible = false;
        //regUser.Visible = false;

        lblUser.Text =  userDto.username ;
       
       
        
        //if (userDto.userTypeDto.name.Trim() == "Admin")
        //{
        //    control.Visible = true;
        //    regUser.Visible = true;
        //}
      
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        
        Session.Abandon();
        Session.Clear();
        
        Response.Redirect("LoginPage.aspx");
    } 
}