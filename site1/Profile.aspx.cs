using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_Profile : System.Web.UI.Page
{

    private EmployeeDTO employee;
    private EmployeeDAO serviceEmployee = new EmployeeDAO();
    private UserDTO userDtoUpdate;
    private UserDTO userDto;
    private UserDAO serviceUsers = new UserDAO();
    private DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        session();
        if(!IsPostBack)
            loadProfile();
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();

        Response.Redirect("Default.aspx");
    }

    private void loadProfile()
    {
        employee = serviceEmployee.getEmployee(userDto.Id);
        txtName.Text = employee.employeeName;
        txtSurname.Text = employee.employeeSurname;
        txtCellNumber.Text = employee.employeeCellNumber;
        txtDateHired.Text = employee.dateHired;
        txtSuburb.Text = employee.employeeSuburb;
        txtAddress.Text = employee.employeeStreetName;
        txtPostalCode.Text = employee.employeePostalCode;
        try
        {
            dt = serviceUsers.getLoginDetails(userDto.Id);
            foreach (DataRow row in dt.Rows)
            {
                txtPassword.Text = row["pass"].ToString();
                txtUsername.Text = row["userName"].ToString();
            }
            dt = serviceEmployee.getHolidayInfo(userDto.Id.ToString());
            foreach (DataRow row in dt.Rows)
            {
                txtLeaveDays.Text = row["HolidaysExPublic"].ToString();
                txtReligiousDays.Text = row["ReligiousHolidays"].ToString();
                txtSickDays.Text = row["SickLeaveDays"].ToString();
            }
            lockEmutableData();
        }
        catch(Exception ex){
            ExceptionRedirect(ex);
        }
    }

    private void lockEmutableData()
    {
        txtDateHired.Enabled = false;
        txtLeaveDays.Enabled = false;
        txtReligiousDays.Enabled = false;
        txtSickDays.Enabled = false;
    }

    private void session()
    {
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        userDto = (UserDTO)Session["userDto"];
        if (userDto == null)
            Response.Redirect("Default.aspx");
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        lblUser.Text = userDto.username;
        if (userDto.userTypeName.Trim() != "Admin")
            AdminLinkPanel.Visible = false;
        else
            userPanel.Visible = false;
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {

        employee = new EmployeeDTO.EmployeeBuilder()
        .empNumber(userDto.Id)
        .empName(txtName.Text)
        .empSurname(txtSurname.Text)
        .empCellNumber(txtCellNumber.Text)
        .empAddress(txtAddress.Text,txtSuburb.Text,txtPostalCode.Text)
        .build();

        UserDTO update = new UserDTO.UserBuilder()
            .copy(userDto)
            .buildPassword(txtPassword.Text)
            .buildUsername(txtUsername.Text)
            .build();

        try
        {
            serviceEmployee.save(employee);
            serviceUsers.UpdateUser(update);
        }
        catch(Exception ex)
        {
            ExceptionRedirect(ex);     
        }
    }

    private void ExceptionRedirect(Exception ex)
    {
        Response.Redirect("ErrorPage.aspx?ErrorMessage=" + ex.Message.Replace('\n', ' '), false);
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
       
    }
}