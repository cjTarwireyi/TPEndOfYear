using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_Users : System.Web.UI.Page
{
    UserDTO userDto = new UserDTO();
    protected void Page_Load(object sender, EventArgs e)
    {
        UserDTO userDtoUpdate = new UserDTO();
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        userDto = (UserDTO)Session["userDto"];
        if (userDto == null )
            Response.Redirect("LoginPage.aspx");
        lblUser.Text = userDto.username;

        if (userDto.userTypeName.Trim() != "Admin")
            
            AdminLinkPanel.Visible = false;
    }

    protected void Register_Click(object sender, EventArgs e)
    {


        Response.Redirect("../site1/RegistrationPage.aspx");

    }


    protected void Update(object sender, EventArgs e)
    {

        UserTypeDTO userType = new UserTypeDTO();


        if (GridView1.SelectedIndex > -1)
        {
            GridViewRow row = GridView1.SelectedRow;
            int userId;
            int empno = 2;

            Label lblId = (Label)row.FindControl("lblUserId");
            if (lblId.Text == "")
            {
                userId = 0;
            }
            else
            {
                userId = Convert.ToInt32(lblId.Text);
            }
            userDto.Id = Convert.ToInt32(userId);

            userDto.name = row.Cells[2].Text;
            userDto.password = row.Cells[3].Text;
            string type = row.Cells[6].Text;

            // userDto.userTypeDto.name =  userType.name;
            Session["userUpdate"] = userDto;
            Session["userTypeUpdate"] = type;
            Session["empNo"] = empno;
            Session["userId"] = userId;
            Response.Redirect("../site1/RegistrationPage.aspx");

        }
        else
        {

        }
    }
    protected void RemoveUser(object sender, EventArgs e)
    {

        if (GridView1.SelectedIndex > -1)
        {
            UserFacade facade = new UserFacade();
            GridViewRow row = GridView1.SelectedRow;


            Label lblId = (Label)row.FindControl("lblUserId");
            int userId = Convert.ToInt32(lblId.Text);
            facade.deleteUser(userId);

        }
        Response.Redirect("Users.aspx");

    }
    protected void Submit_Click(object sender, EventArgs e)
    {

        Session.Abandon();
        Session.Clear();

        Response.Redirect("LoginPage.aspx");
    }

}