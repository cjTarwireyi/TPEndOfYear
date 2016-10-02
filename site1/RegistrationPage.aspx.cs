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
    

    protected void Page_Load(object sender, EventArgs e) {

        //if (IsPostBack){
        //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminBookingConnectionString"].ConnectionString);
        //    con.Open();

        //    string checkTechnician = "SELECT COUNT(*) FROM Technician WHERE username='" + Username.Text + "'";
        //    SqlCommand cmd = new SqlCommand(checkTechnician,con);

        //    int rows = Convert.ToInt32(cmd.ExecuteScalar().ToString());
        //    if (rows == 1) {
        //        string message = "The username already eists..";
        //        string content = "window.onload=function(){ alert('";
        //        content += message;

        //        content += "');";
        //        content += "window.location='";
        //        content += Request.Url.AbsoluteUri;
        //        content += "';}";
        //        ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", content, true);
        //    }

        //    con.Close();
        //}
        Control control = Master.FindControl("sideNav");
        Label loginControl = (Label)Master.FindControl("loginLable");

        UserDTO userDto = new UserDTO();
        userDto = (UserDTO)Session["userDto"];

        control.Visible = false;
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
        }

    }
    protected void Register_Click(object sender, EventArgs e)
    {
        try{


            UserFacade userFacade = new UserFacade();
            userFacade.makeUser(Username.Text, Rpassword.Text, 2);

            

           
        }catch(Exception ex){
            Response.Write("Error: "+ ex.ToString());
        }

    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = CheckBox1.Checked;
    }
}