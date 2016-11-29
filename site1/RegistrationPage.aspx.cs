using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class RegistrationPage : System.Web.UI.Page
{
    private UserTypeFacade facade = new UserTypeFacade();
    private UserDTO userDtoUpdate = new UserDTO();
    protected void Page_Load(object sender, EventArgs e)
    {

        UserDTO userDto = new UserDTO();
        string type;
        int empno = 0;

        UserDTO userDtoUpdate = new UserDTO();

        userDtoUpdate = (UserDTO)Session["userUpdate"];
        // Session.Remove("userUpdate");
        userDto = (UserDTO)Session["userDto"];
        if (userDto == null)
            Response.Redirect("LoginPage.aspx");
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        //Session.Remove("userUpdate");
        lblUser.Text = userDto.username;




        userType.Items.Clear();
        userType.Items.AddRange(facade.getUserTypes().ToArray());

        type = (string)Session["userTypeUpdate"];
        if (lblTitle.Text != "User Update")
        {
            if (userDtoUpdate != null)
            {
                lblTitle.Text = "User Update";
                userType.Text = type;
                Username.Text = userDtoUpdate.name;
                empNo.Enabled = false;
                oldPass.Enabled = true;
            }
        }
        if (lblTitle.Text == "User Update")
        {
            empno = (int)Session["empNo"];
            empNo.Text = empno.ToString();
        }

        if (userDto.userTypeName.Trim() == "Admin")
        {
            //  control.Visible = true;
        }

    }
    protected void Register_Click(object sender, EventArgs e)
    {
        UserDTO userDto = new UserDTO();
        UserFacade userFacade = new UserFacade();
        userDtoUpdate = (UserDTO)Session["userUpdate"];


        int uId = 0;



        if (oldPasWrong.Visible == true) { oldPasWrong.Visible = false; }
        if (lblErrorEmp.Visible == true) { lblErrorEmp.Visible = false; }
        if (usernameError.Visible == true) { usernameError.Visible = false; }
        if (pword.Text == "" || Rpassword.Text == "")
        {

        }
        else if (pword.Text != Rpassword.Text)
        {

        }
        else
        {
            try
            {
                if (facade.getEmployee(Convert.ToInt32(empNo.Text)) == "ok")
                {
                    if (lblTitle.Text == "User Update")
                    {
                        if (userDtoUpdate.password.Trim() == oldPass.Text.Trim())
                        {
                            uId = (int)Session["userId"];
                            userFacade.updateUser(Username.Text, Rpassword.Text, Convert.ToInt32(userFacade.getUserTypeId(userType.Text)), uId);
                            Session.Remove("userUpdate");
                            Session.Remove("userTypeUpdate");
                            Session.Remove("userId");
                            Username.Text = string.Empty;
                            Rpassword.Text = string.Empty;
                            empNo.Text = string.Empty;
                        }
                        else
                        {
                            oldPasWrong.Visible = true;
                        }
                    }
                    else
                    {//ADDING USER
                        if (userFacade.userExist(Username.Text) == false && lblTitle.Text != "User Update")
                        {

                            userFacade.makeUser(Username.Text, Rpassword.Text, Convert.ToInt32(userFacade.getUserTypeId(userType.Text)));
                        }

                        else
                        {
                            usernameError.Visible = true;
                        }
                    }
                }
                else
                {
                    lblErrorEmp.Visible = true;
                }
            }
            catch (FormatException ex)
            {

                lblErrorEmp.Visible = true;
            }
            catch (OverflowException ex)
            {

                lblErrorEmp.Visible = true;
            }

        }
        Username.Text = string.Empty;
        Rpassword.Text = string.Empty;
        empNo.Text = string.Empty;
        userType.SelectedIndex = -1;


    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = CheckBox1.Checked;
    }
    protected void Submit_Click(object sender, EventArgs e)
    {

        Session.Abandon();
        Session.Clear();

        Response.Redirect("LoginPage.aspx");
    }
}