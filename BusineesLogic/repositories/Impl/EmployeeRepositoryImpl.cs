using BusineesLogic.domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.repositories.Impl
{
    public class EmployeeRepositoryImpl : EmployeeRepository
    {
        private SqlConnection con;
        public EmployeeRepositoryImpl()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminBookingConnectionString"].ConnectionString);
        }
        public void save(EmployeeDTO entity)
        {
            DataTable dt = new DataTable();
            dt = getHolidayInfo(entity.employeeNumber.ToString());

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            if (entity.employeeNumber == 0)
                cmd.CommandText = "insert into Employees([EmployeeName], [EmployeeSurname], [EmployeeCellNumber], [EmployeeStreetName],[EmployeeSuburb],[EmployeePostalCode],[DateHired])values('" + entity.employeeName + "','" + entity.employeeSurname + "','" + entity.employeeCellNumber + "','" + entity.employeeStreetName + "','" + entity.employeeSuburb + "','" + entity.employeePostalCode + "','" + DateTime.Now + "" + "')";
            else
                cmd.CommandText = "update employees set employeeName ='" + entity.employeeName + "', employeeSurname='" + entity.employeeSurname + "',employeeCellNumber='" + entity.employeeCellNumber + "',employeeStreetName='" + entity.employeeStreetName + "', employeeSuburb ='" + entity.employeeSuburb + "',employeePostalCode='" + entity.employeePostalCode + "' where employeeID = '" + entity.employeeNumber + "' ";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void update(EmployeeDTO entity)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update employees set employeeName ='" + entity.employeeName + "', employeeSurname='" + entity.employeeSurname + "',employeeCellNumber='" + entity.employeeCellNumber + "',employeeStreetName='" + entity.employeeStreetName + "', employeeSuburb ='" + entity.employeeSuburb + "',employeePostalCode='" + entity.employeePostalCode + "' where employeeID = '" + entity.employeeNumber + "' ";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void delete(int id)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from employees where employeeID = '" + id + "' ";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public System.Data.DataTable findAll()
        {
            DataTable employees = new DataTable();
            string query = "select EmployeeID, Concat(EmployeeName,EmployeeSurname) As empName from employees order by employeeID DESC";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(employees);
            da.Dispose();
            con.Close();
            return employees;
        }

        public void saveHoliday(HolidaysDTO emp, string id)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            if (emp.employeeID == null)
                cmd.CommandText = "insert into EmployeeHolidays([EmployeeID], [HolidaysExPublic], [ReligiousHolidays], [SickLeaveDays],[ApprovedBy])values('" + id + "','" + emp.daysExcludingPublic + "','" + emp.religiousHolidays + "','" + emp.sickLeaveDays + "','" + emp.employeeID + "')";
            else
                cmd.CommandText = "update employeeHolidays set holidaysExPublic ='" + emp.daysExcludingPublic + "', sickLeaveDays='" + emp.sickLeaveDays + "', religiousHolidays='" + emp.religiousHolidays + "',approvedBy ='" + id + "' where employeeID = '" + emp.employeeID + "' ";
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


        public EmployeeDTO findByID(int id)
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


        public void updateEmployee(string id, List<string> employee)
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

        public DataTable searchEmployee(string id)
        {
            DataTable employees = new DataTable();
            string query = "select * from employees where employeeID = '" + id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(employees);
            da.Dispose();
            con.Close();
            return employees;
        }

        public EmployeeDTO getLastReocrd()//last customer
        {
            EmployeeDTO employee = null;
            con.Open();
            String selectCustomer = "SELECT TOP 1 * FROM  employees Order by employeeID DESC ";
            SqlCommand myComm = new SqlCommand(selectCustomer, con);
            SqlDataReader myDR;
            myDR = myComm.ExecuteReader();
            if (myDR.Read())
                employee = makeEmployeeDTO(myDR);
            con.Close();
            return employee;
        }
    }
}
