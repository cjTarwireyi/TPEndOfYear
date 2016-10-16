using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_ConfirmCustomer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserDTO userDtoUpdate = new UserDTO();
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        CustomerDTO customer = (CustomerDTO)Session["CustomerDTO"];
        lblName.Text = customer.name;
        lblSurname.Text = customer.surname;
        lblCellNumber.Text = customer.cellNumber;
        lblStreet.Text = customer.StreetName;
        lblSurbub.Text = customer.Suburb;
        lblPostalCode.Text = customer.postalCode;
    }
    protected void Register_Click(object sender, EventArgs e)
    {
        CustomerDTO customerDTO = (CustomerDTO)Session["CustomerDTO"];
        CustomerDAO customer = new CustomerDAO();
        customer.saveCustomer(customerDTO);
        Response.Redirect("Customers.aspx");

    }
}