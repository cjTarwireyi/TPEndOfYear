using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_AddCustomer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserDTO userDtoUpdate = new UserDTO();
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            String name = txtName.Text;
            String surname = txtSurname.Text;
            String cellNumber = txtCellNumber.Text;
            String streetName = txtStreetName.Text;
            String suburb = txtSuburb.Text;
            String postal = txtPostalCode.Text;
            String email = Email.Text;

            CustomerDTO customer = new CustomerDTO();
            customer.name = name;
            customer.surname = surname;
            customer.cellNumber = cellNumber;
            customer.email = email;
            customer.StreetName = streetName;
            customer.Suburb = suburb;
            customer.postalCode = postal;
            Session["CustomerDTO"] = customer;
        }
        catch (Exception ex)
        {

        }
        finally
        {
            Server.Transfer("ConfirmCustomer.aspx", true);
        }


    }

    

}