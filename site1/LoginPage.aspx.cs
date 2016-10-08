using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

 
public partial class LoginPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         
        
            Label regUser = (Label)Master.FindControl("regUser");
            Control control = Master.FindControl("sideNav");
            regUser.Visible = false;


            // Control logoutControl = Master.FindControl("logOut");
            control.Visible = false;
            //  logoutControl.Visible = false;
            if (Session.IsNewSession)
            {
        }

        else
        {
            Session.Abandon();
            Session.Clear();
        }
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
      //  UserTypeDTO usertypeDto = new UserTypeDTO();
        UserFacade userFacade = new UserFacade();

        UserDTO userDto = new UserDTO();
       // UserDTO empty = new UserDTO();
        userDto = userFacade.login(username.Text, password.Text);

        //ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", "alert('Successfuly posted')", true);ClientScript.RegisterStartupScript(this.GetType(),"PopupScript","alert('Successfuly posted')",true);
        if (userDto.username != null || userDto.password != null)
        {
            if ((userDto.username.Trim() == username.Text.Trim()) || (userDto.password.Trim() == password.Text.Trim()))
            {
                string userRole = "admin";
                Session["userDto"] = userDto;
                //if(Session.)
                //    Response.Redirect("../site1/LoginPage.aspx");
                //else
                Response.Redirect("../site1/Home.aspx");
            }
            else
            {
                Label1.Text = "Wrong Log in credentials";
            }
        }
        else
        {

            Label1.Text = "Wrong Log in credentials";
           

            // userDto.username = username.Text;
            // userDto.password = password.Text;
            // userDto.password = userRole;

            
        }


    }
    
    
}