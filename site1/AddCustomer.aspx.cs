using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_AddCustomer : System.Web.UI.Page
{
    private UserDTO userDto;
    private UserDTO userDtoUpdate;
    protected void Page_Load(object sender, EventArgs e)
    {
        session();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string name = txtName.Text;
        string surname = txtSurname.Text;
        string cellNumber = txtCellNumber.Text;
        string streetName = txtStreetName.Text;
        string suburb = txtSuburb.Text;
        string postal = txtPostalCode.Text;
        string email = Email.Text;

        CustomerDTO customer = new CustomerDTO.CustomerBuilder()
            .custName(name)
            .custSurname(surname)
            .custCellNumber(cellNumber)
            .custEmail(email)
            .custAddress(streetName, suburb, postal)
            .build();
        Session["CustomerDTO"] = customer;
        Server.Transfer("ConfirmCustomer.aspx", true);
    }
    private void session()
    {
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        userDto = (UserDTO)Session["userDto"];
        if (userDto == null)
            Response.Redirect("LoginPage.aspx");
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
    }
}