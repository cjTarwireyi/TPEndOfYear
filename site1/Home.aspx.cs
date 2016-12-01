using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    private UserDTO userDtoUpdate;
    private UserDTO userDto;
    protected void Page_Load(object sender, EventArgs e) 
    {
        session();
        
      //  AdminLinkPanel.Visible = false;
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        
        Session.Abandon();
        Session.Clear();
        Response.Redirect("LoginPage.aspx");
    }

    private void session()
    {
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        userDto = (UserDTO)Session["userDto"];
        if (userDto == null)
            Response.Redirect("LoginPage.aspx");

        else
            lblUser.Text = userDto.username;
        if(userDto.userTypeName.Trim()!="Admin")
            AdminLinkPanel.Visible = false;
    }
}