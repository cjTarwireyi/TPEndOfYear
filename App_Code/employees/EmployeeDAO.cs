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
        //try
        //{
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Employees([EmployeeName], [EmployeeSurname], [EmployeeCellNumber], [EmployeeStreetName],[EmployeeSuburb],[EmployeePostalCode],[DateHired])values('" + emp.employeeName + "','" + emp.employeeSurname + "','" + emp.employeeCellNumber + "','" + emp.employeeStreetName + "','" + emp.employeeSuburb + "','" + emp.employeePostalCode + "','"+DateTime.Now+""+"')";
            cmd.ExecuteNonQuery();
            con.Close();
       // }
        //catch (Exception e)
        //{

        //}
        //finally
        //{
        //    con.Close();
        //}
    }

    public EmployeeDTO makeTechDTO(SqlDataReader myDR)
    {
        EmployeeDTO employee = new EmployeeDTO();
        employee.employeeNumber = myDR.GetInt32(0);
        employee.employeeName = myDR.GetString(1);
        employee.employeeSurname = myDR.GetString(2);
        employee.employeeCellNumber = myDR.GetString(3);
        employee.employeeStreetName = myDR.GetString(4);
        employee.employeeSuburb = myDR.GetString(5);
        employee.employeePostalCode = myDR.GetString(6);
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
        EmployeeDTO updateEmployee = makeTechDTO(myDR);
        con.Close();
        return updateEmployee;
    }
}