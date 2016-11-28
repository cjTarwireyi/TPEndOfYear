using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EmployeeDAO
/// </summary>
public class EmployeeDAO
{
    private SqlConnection con;
    public EmployeeDAO()
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminBookingConnectionString"].ConnectionString);
    }

    public void saveEmployee(EmployeeDTO emp)
    {
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "insert into Employees([EmployeeName], [EmployeeSurname], [EmployeeCellNumber], [EmployeeStreetName],[EmployeeSuburb],[EmployeePostalCode],[DateHired])values('" + emp.employeeName + "','" + emp.employeeSurname + "','" + emp.employeeCellNumber + "','" + emp.employeeStreetName + "','" + emp.employeeSuburb + "','" + emp.employeePostalCode + "','" + DateTime.Now + "" + "')";
        cmd.ExecuteNonQuery();
        con.Close();
    }

    public EmployeeDTO makeEmployeeDTO(SqlDataReader myDR)
    {
         EmployeeDTO employee = new EmployeeDTO.EmployeeBuilder()
        .empNumber(myDR.GetInt32(0))
        .empName(myDR.GetString(1))
        .empSurname(myDR.GetString(2))
        .empCellNumber(myDR.GetString(3))
        .empAddress(myDR.GetString(4), myDR.GetString(5), myDR.GetString(6))
        .build();
        return employee;
    }

    public EmployeeDTO getEmployee(int id)
    {
        con.Open();
        String selectEmployee = "select * from Employees where EmployeeID =" + id + " ";
        SqlCommand myComm = new SqlCommand(selectEmployee, con);
        SqlDataReader myDR;
        myDR = myComm.ExecuteReader();
        if (!myDR.Read())
            return null;
        EmployeeDTO updateEmployee = makeEmployeeDTO(myDR);
        con.Close();
        return updateEmployee;
    }

    public DataTable populateGrid()
    {
        DataTable employees = new DataTable();
        string query = "select * from employees";
        con.Open();
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(employees);
        da.Dispose();
        con.Close();
        return employees;
    }   
}