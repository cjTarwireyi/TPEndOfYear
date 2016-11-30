using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_AddEmployee : System.Web.UI.Page
{
    private UserDTO userDto;
    private UserDTO userDtoUpdate;
    protected void Page_Load(object sender, EventArgs e)
    {
        session();
    }
    protected void Register_Click(object sender, EventArgs e)
    {
            string name = FullName.Text;
            string surname = Surname.Text;
            string cellNumber = Phone.Text;
            string streetName = txtStreet.Text;
            string postalCode = txtPostalCode.Text;
            string suburb = txtSuburb.Text;

            EmployeeDTO employee = new EmployeeDTO.EmployeeBuilder()
            .empName(name)
            .empSurname(surname)
            .empCellNumber(cellNumber)
            .empAddress(streetName, suburb, postalCode)
            .build();
            Session["EmployeeDTO"] = employee;
            Server.Transfer("EmployeeConfirm.aspx", true);
    }

    private void ExceptionRedirect(Exception ex)
    {
        Response.Redirect("ErrorPage.aspx?ErrorMessage=" + ex.Message.Replace('\n', ' '), false);
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