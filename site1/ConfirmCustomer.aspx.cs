using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_ConfirmCustomer : System.Web.UI.Page
{
    private CustomerDAO customer = new CustomerDAO();
    private UserDTO userDtoUpdate;
    private UserDTO userDto;
    private CustomerDTO customerDTO;
    protected void Page_Load(object sender, EventArgs e)
    {
        session();
    }
    protected void Register_Click(object sender, EventArgs e)
    {
        customerDTO = (CustomerDTO)Session["CustomerDTO"];
       // try
        //{
            customer.save(customerDTO);
            SendMail();
            Response.Redirect("Customers.aspx");
        //}
        //catch (Exception ex)
        //{
        //    ExceptionRedirect(ex);
        //}
    }

    private void ExceptionRedirect(Exception ex)
    {
        Response.Redirect("ErrorPage.aspx?ErrorMessage=" + ex.Message.Replace('\n', ' '), false);
    }

    private void SendMail()
    {

        customerDTO = (CustomerDTO)Session["CustomerDTO"];
        string fromAddress = "siraaj.wilkonson1995@gmail.com";
        string toAddress = customerDTO.email.ToString();
        const string fromPassword = "wilkonson1995";
        string subject = "Customer Number Keep Safe";
        string body = "Hi " + customerDTO.name + " " + customerDTO.surname + "\nYour customer number is:" + "'" + customer.getLastReocrd() + "'" + "Please keep it safe as it would be required from you everytime you purchase items";
        try
        {
            // smtp settings4
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 20000;
            }
            // Passing values to smtp object
            smtp.Send(fromAddress, toAddress, subject, body);
        }
        catch(SmtpException ex)
        {
            ExceptionRedirect(ex);
        }
    }

    private void session()
    {
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        customerDTO = (CustomerDTO)Session["CustomerDTO"];
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        userDto = (UserDTO)Session["userDto"];
        if (userDto == null)
            Response.Redirect("Default.aspx");
        else
            lblName.Text = customerDTO.name;
        lblSurname.Text = customerDTO.surname;
        lblCellNumber.Text = customerDTO.cellNumber;
        lblEmail.Text = customerDTO.email;
        lblStreet.Text = customerDTO.StreetName;
        lblSurbub.Text = customerDTO.Suburb;
        lblPostalCode.Text = customerDTO.postalCode;
    }
}