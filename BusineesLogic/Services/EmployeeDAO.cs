using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BusineesLogic.Interface;
using BusineesLogic.domain;
 

/// <summary>
/// Summary description for EmployeeDAO
/// </summary>
public class EmployeeDAO : IDatabaseFunctions
{
    private SqlConnection con;
    public EmployeeDAO()
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminBookingConnectionString"].ConnectionString);
    }

    public void save(EmployeeDTO emp)
    {
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        if (getHolidayInfo(emp.employeeNumber.ToString()) == null )
        {
            cmd.CommandText = "insert into Employees([EmployeeName], [EmployeeSurname], [EmployeeCellNumber], [EmployeeStreetName],[EmployeeSuburb],[EmployeePostalCode],[DateHired])values('" + emp.employeeName + "','" + emp.employeeSurname + "','" + emp.employeeCellNumber + "','" + emp.employeeStreetName + "','" + emp.employeeSuburb + "','" + emp.employeePostalCode + "','" + DateTime.Now + "" + "')";
        }
        else
        cmd.CommandText = "update employees set employeeName ='" + emp.employeeName + "', employeeSurname='" + emp.employeeSurname + "',employeeCellNumber='" + emp.employeeCellNumber + "',employeeStreetName='" + emp.employeeStreetName + "', employeeSuburb ='" + emp.employeeSuburb + "',employeePostalCode='" + emp.employeePostalCode + "' where employeeID = '" + emp.employeeNumber + "' ";

        cmd.ExecuteNonQuery();
        con.Close();
    }

    public void saveHoliday(HolidaysDTO emp,string id)
    {
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        if(emp.employeeID == null)
            cmd.CommandText = "insert into EmployeeHolidays([EmployeeID], [HolidaysExPublic], [ReligiousHolidays], [SickLeaveDays],[ApprovedBy])values('" +id+ "','" + emp.daysExcludingPublic + "','" + emp.religiousHolidays + "','" + emp.sickLeaveDays + "','" + emp.employeeID + "')";
        else
            cmd.CommandText = "update employeeHolidays set holidaysExPublic ='"+emp.daysExcludingPublic+"', sickLeaveDays='"+emp.sickLeaveDays+"', religiousHolidays='"+emp.religiousHolidays+"',approvedBy ='"+id+"' where employeeID = '"+emp.employeeID+"' ";
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
        .empDateHired(myDR.GetString(7))
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
        string query = "select * from employees order by employeeID DESC";
        con.Open();
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(employees);
        da.Dispose();
        con.Close();
        return employees;
    }

    public void delete(string id)
    {
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "delete from employees where employeeID = '" + id + "' ";
        cmd.ExecuteNonQuery();
        con.Close();
    }

    public void update(string id, List<string> employee)
    {
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "update employees set employeeName ='" + employee[0] + "', employeeSurname='" + employee[1] + "',employeeCellNumber='" + employee[2] + "',employeeStreetName='" + employee[3] + "', employeeSuburb ='" + employee[4] + "',employeePostalCode='" + employee[5] + "' where employeeID = '" + id + "' ";
        cmd.ExecuteNonQuery();
        con.Close();
    }

    public DataTable getHolidayInfo(string id)
    {
        DataTable employees = new DataTable();
        string query = "select * from employeeHolidays where employeeID = '" + id + "'";
        con.Open();
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(employees);
        da.Dispose();
        con.Close();
        return employees;
    }
}