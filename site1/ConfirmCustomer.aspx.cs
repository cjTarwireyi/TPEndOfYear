using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_ConfirmCustomer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CustomerDTO customer = (CustomerDTO)Session["CustomerDTO"];
        lblName.Text = customer.name;
        lblSurname.Text = customer.surname;
        lblCellNumber.Text = customer.cellNumber;
        lblEmail.Text = customer.email;
        lblStreet.Text = customer.StreetName;
        lblSurbub.Text = customer.Suburb;
        lblPostalCode.Text = customer.postalCode;
    }
    protected void Register_Click(object sender, EventArgs e)
    {
        CustomerDTO customerDTO = (CustomerDTO)Session["CustomerDTO"];
        CustomerDAO customer = new CustomerDAO();
        customer.saveCustomer(customerDTO);
        SendMail();
        Response.Redirect("Customers.aspx");

    }


    private void SendMail()
    {
        CustomerDTO customer = (CustomerDTO)Session["CustomerDTO"];
        string fromAddress = "siraaj.wilkonson1995@gmail.com";
        string toAddress = customer.email.ToString();
        const string fromPassword = "wilkonson1995";
        string subject = "Customer Number Keep Safe";
        string body = "Your custumer number is: ?????\nPlease keep it safe as it would be required from you everytime you purchase items";

        // smtp settings
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
}