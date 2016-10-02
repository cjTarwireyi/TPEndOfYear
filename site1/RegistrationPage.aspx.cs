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

        if (IsPostBack){
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminBookingConnectionString"].ConnectionString);
            con.Open();

            string checkTechnician = "SELECT COUNT(*) FROM Technician WHERE username='" + Username.Text + "'";
            SqlCommand cmd = new SqlCommand(checkTechnician,con);

            int rows = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            if (rows == 1) {
                string message = "The username already eists..";
                string content = "window.onload=function(){ alert('";
                content += message;

                content += "');";
                content += "window.location='";
                content += Request.Url.AbsoluteUri;
                content += "';}";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", content, true);
            }

            con.Close();
        }

    }
    protected void Register_Click(object sender, EventArgs e)
    {
        try{

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminBookingConnectionString"].ConnectionString);
            con.Open();

            string insertQuery
            = "INSERT INTO Technician (techName,techSurname,techContact,techEmail,techPassword,username) VALUES (@name,@surname,@contact,@email,@password,@username)";
            SqlCommand cmd = new SqlCommand(insertQuery, con);

            cmd.Parameters.AddWithValue("@username", Username.Text);
            //cmd.Parameters.AddWithValue("@name",FullName.Text);
            cmd.Parameters.AddWithValue("@surname", Surname.Text);
            cmd.Parameters.AddWithValue("@contact", Phone.Text);
            cmd.Parameters.AddWithValue("@email", Email.Text);
            cmd.Parameters.AddWithValue("@password", password.Text);

            cmd.ExecuteNonQuery();

            string message = "You have been successfully registered..";
            string content = "window.onload=function(){ alert('";
            content += message;

            content += "');";
            content += "window.location='";
            content += Request.Url.AbsoluteUri;
            content += "';}";
            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", content, true);
            


            

            con.Close();

        }catch(Exception ex){
            Response.Write("Error: "+ ex.ToString());
        }

    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = CheckBox1.Checked;
    }
}