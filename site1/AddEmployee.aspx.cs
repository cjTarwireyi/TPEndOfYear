using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_AddEmployee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserDTO userDtoUpdate = new UserDTO();
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
    }
    protected void Register_Click(object sender, EventArgs e)
    {
        try
        {

            String name = FullName.Text;
            String surname = Surname.Text;
            String cellNumber = Phone.Text;
            String streetName = txtStreet.Text;
            String postalCode = txtPostalCode.Text;
            String suburb = txtSuburb.Text;
          


            EmployeeDTO employee = new EmployeeDTO();
            employee.employeeName = name;
            employee.employeeSurname = surname;
            employee.employeeCellNumber = cellNumber;
            employee.employeeStreetName = streetName;
            employee.employeePostalCode = postalCode;
            employee.employeeSuburb = suburb;
            Session["EmployeeDTO"] = employee;
            Server.Transfer("EmployeeConfirm.aspx", true);
        }
        catch (Exception ex)
        {
            //Response.Write("Error: " + ex.ToString());
        }
    }
}