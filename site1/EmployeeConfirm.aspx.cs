using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_EmployeeConfirm : System.Web.UI.Page
{
    private UserDTO userDtoUpdate;
    private UserDTO userDto;
    private EmployeeDTO employeeDTO;
    private EmployeeDAO employee = new EmployeeDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        session();   
    }
        
        
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        //try
        //{
            employeeDTO = (EmployeeDTO)Session["EmployeeDTO"];
            employee.save(employeeDTO);
            Response.Redirect("Employee.aspx");
       // }
        //catch(Exception ex)
        //{
        //    ExceptionRedirect(ex);
        //}

    }

    private void ExceptionRedirect(Exception ex)
    {
        Response.Redirect("ErrorPage.aspx?ErrorMessage=" + ex.Message.Replace('\n', ' '), false);
    }

    private void session()
    {
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        employeeDTO = (EmployeeDTO)Session["EmployeeDTO"];
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        userDto = (UserDTO)Session["userDto"];
        if (userDto == null)
            Response.Redirect("LoginPage.aspx");
        else
           lblName.Text = employeeDTO.employeeName;
           lblSurname.Text = employeeDTO.employeeSurname;
           lblCellNumber.Text = employeeDTO.employeeCellNumber;
           lblStreet.Text = employeeDTO.employeeStreetName;
           lblSurbub.Text = employeeDTO.employeeSuburb;
           lblPostalCode.Text = employeeDTO.employeePostalCode;
    }
}