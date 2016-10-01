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
        Control control = Master.FindControl("sideNav");
        control.Visible = false;

    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        UserDAO userDao = new UserDAO();
        UserDTO userDto = new UserDTO();
        UserDTO empty = new UserDTO();
        userDto = userDao.getUser(username.Text, password.Text);
        
        //ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", "alert('Successfuly posted')", true);ClientScript.RegisterStartupScript(this.GetType(),"PopupScript","alert('Successfuly posted')",true);
        if (userDto.username==null )
            {
                Label1.Text = "Wrong Log in credentials";
            }
        else
        {           
             
             
                string userRole = "admin";
               
               // userDto.username = username.Text;
               // userDto.password = password.Text;
               // userDto.password = userRole;

                Session["userDto"] = userDto;
            //if(Session.)
            //    Response.Redirect("../site1/LoginPage.aspx");
            //else
                Response.Redirect("../site1/Home.aspx");
            }

            

        }
         
    
}