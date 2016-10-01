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

    public void saveEmployee(Employee emp)
    {
        try
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
           // cmd.CommandText = "insert into Technician([techName], [techSurname], [techContact], [techEmail],[StreetName],[Suburb],[PostalCode],[password],[username])values('" + emp.name + "','" + emp.surname + "','" + emp.cellNumber + "','" + emp.email + "','" + emp.streetName + "','" + emp.suburb + "','" + emp.postalCode + "','" + emp.password + "','" + emp.username + "')";
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception e)
        {
        }
        finally
        {
            con.Close();
        }
    }

    public Employee makeTechDTO(SqlDataReader myDR)
    {
        Employee employee = new Employee();
        employee.employeeNumber = myDR.GetInt32(0);
        return employee;
    }

    public Employee getEmployee(int techNumber)
    {
        con.Open();
       // String selectEmployee = "select * from Technician where techID =" + techNumber + " ";
        //SqlCommand myComm = new SqlCommand(selectEmployee, con);
        SqlDataReader myDR;
        /*myDR = myComm.ExecuteReader();
        if (!myDR.Read())
            return null;
        Employee updateEmployee = makeTechDTO(myDR);*/
        con.Close();
        //return updateEmployee;
        return null;
    }
}