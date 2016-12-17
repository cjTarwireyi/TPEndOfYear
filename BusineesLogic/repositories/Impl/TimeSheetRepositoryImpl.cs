using BusineesLogic.domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace BusineesLogic.repositories.Impl
{
    public class TimeSheetRepositoryImpl : TimeSheetRepository
    {
        private SqlConnection con;
        public TimeSheetRepositoryImpl()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminBookingConnectionString"].ConnectionString);
        }

        public void save(domain.TimeSheetDTO entity)
        {
            throw new NotImplementedException();
        }

        public void update(domain.TimeSheetDTO entity)
        {
            throw new NotImplementedException();
        }

        public void delete(int id)
        {
            throw new NotImplementedException();
        }
        
        public DataTable findAll()
        {
            DataTable timesheets = new DataTable();
            string query = "select id,DateWorked,TimeIn,TimeOut,Comments, Concat(EmployeeName,EmployeeSurname)AS empName from TimeSheet inner join Employees on Timesheet.EmployeeID = Employees.EmployeeID  Order by id DESC";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(timesheets);
            da.Dispose();
            con.Close();
            return timesheets;
        }

        public domain.TimeSheetDTO findByID(int id)
        {
            throw new NotImplementedException();
        }
        public bool addTimeSheet(TimeSheetDTO model)
        {
            try
            {
                var Datetime = DateTime.Now;

                con.Open();
                string insertQuery = "INSERT INTO TimeSheet (DateWorked,TimeIn,TimeOut,EmployeeID,Comments) VALUES ('" + model.date + "','" + model.timeIn + "','" + model.timeOut + "','" + model.employeeId + "','"+model.comments+"')";
                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.ExecuteNonQuery();

                con.Close();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool UpdateTimeSheet(TimeSheetDTO model)
        {
            try
            {
                con.Open();
                string updateQuery = "Update TimeSheet Set DateWorked= '" + model.date + "',TimeIn='" + model.timeIn + "',TimeOut='" + model.timeOut + "',EmployeeID='" + model.employeeId + "', Comments = '"+model.comments+"' Where Id ='" + model.id + "'";
                SqlCommand cmd = new SqlCommand(updateQuery, con);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                con.Open();
                string deleteQuery = "DELETE FROM TimeSheet WHERE  Id ='" + id + "'";
                SqlCommand cmd = new SqlCommand(deleteQuery, con);
                cmd.ExecuteNonQuery();

                con.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public TimeSheetDTO getLastReocrd()
        {
            if (con.State.ToString() == "Open")
                con.Close();
            TimeSheetDTO timeSheet;
            con.Open();
            String selectTimeSheet = "SELECT TOP 1 * FROM  TimeSheet Order by Id DESC ";
            SqlCommand myComm = new SqlCommand(selectTimeSheet, con);
            SqlDataReader reader;
            reader = myComm.ExecuteReader();
            if (!reader.Read())
            {
                timeSheet = null;
            }
            else
            {
                timeSheet = new TimeSheetDTO.TimeSheetBuilder()
                                   .buildId(reader.GetInt32(0))
                                   .buildDate(reader.GetDateTime(2))
                                   .buildTimeIn(reader.GetString(3))
                                   .buildTimeOut(reader.GetString(4))
                                   .buildEmployeeID(reader.GetInt32(1))
                                   .build();

            }
            con.Close();
            return timeSheet;

        }
    }
}
