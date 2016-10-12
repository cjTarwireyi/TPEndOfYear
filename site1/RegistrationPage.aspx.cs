using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class RegistrationPage : System.Web.UI.Page {
   private UserTypeFacade facade = new UserTypeFacade();
  private UserDTO userDtoUpdate = new UserDTO();
    protected void Page_Load(object sender, EventArgs e) {

        UserDTO userDto = new UserDTO();
       
        string type;

        Control control = Master.FindControl("sideNav");
        Label loginControl = (Label)Master.FindControl("loginLable");
        userType.Items.Clear();
        userType.Items.AddRange(facade.getUserTypes().ToArray());
        userDto = (UserDTO)Session["userDto"];
        userDtoUpdate = (UserDTO)Session["userUpdate"];
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
       
        if (userDto == null)
            Response.Redirect("LoginPage.aspx");

        control.Visible = false;
      //  regUser.Visible = false;
        // loginControl.Visible = false;
        loginControl.Text = "Logged in as " + userDto.username + "Logout";

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
          //  regUser.Visible = true;
        }

    }
    protected void Register_Click(object sender, EventArgs e)
    {
        UserDTO userDto = new UserDTO();
        UserFacade userFacade = new UserFacade();
        int empno=0;
        int uId=0;
        
        if (lblTitle.Text == "User Update")
        {
           empno    = (int)Session["empNo"];

      
            empNo.Text = empno.ToString();
        }

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
                             userFacade.updateUser(Username.Text, Rpassword.Text, Convert.ToInt32(userFacade.getUserId(userType.Text)), uId);
                             Session.Remove("userUpdate");
                             Session.Remove("userTypeUpdate");
                             Session.Remove("userId");
                         }
                         else{
                             oldPasWrong.Visible=true;
                         }
                     }
                     else
                     {

                         if (userFacade.userExist(Username.Text) == false && lblTitle.Text == "User Update")
                         {

                             userFacade.makeUser(Username.Text, Rpassword.Text, Convert.ToInt32(userFacade.getUserId(userType.Text)));

                         }

                         else
                         {
                             usernameError.Visible = true;
                         }
                     }
                 }
                   else
                        {
              //  Session.RemoveAll();
                            lblErrorEmp.Visible = true;
                        }
                

           
        }
        catch (FormatException ex)
        {
           // Session.RemoveAll();
            lblErrorEmp.Visible = true;
        }
        catch(OverflowException ex)
        {
           // Session.RemoveAll();
            lblErrorEmp.Visible = true;
        }
       // catch(Exception ex){
         //   Session.RemoveAll();

           //Response.Write("Error: "+ ex.ToString());
        //}
            }
            Username.Text = "";
            userType.SelectedIndex=-1;
            

    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = CheckBox1.Checked;
    }
}