using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_EmployeeConfirm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserDTO userDtoUpdate = new UserDTO();
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        EmployeeDTO employee = (EmployeeDTO)Session["EmployeeDTO"];

        lblName.Text = employee.employeeName;
        lblSurname.Text = employee.employeeSurname;
        lblCellNumber.Text = employee.employeeCellNumber;
        lblStreet.Text = employee.employeeStreetName;
        lblSurbub.Text = employee.employeeSuburb;
        lblPostalCode.Text = employee.employeePostalCode;
    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        EmployeeDTO empDTO = (EmployeeDTO)Session["EmployeeDTO"];
        EmployeeDAO employee = new EmployeeDAO();
        employee.saveEmployee(empDTO);
        Response.Redirect("Employee.aspx");
    }

    private void ExceptionRedirect(Exception ex)
    {
        Response.Redirect("ErrorPage.aspx?ErrorMessage=" + ex.Message.Replace('\n', ' '), false);
    }
}