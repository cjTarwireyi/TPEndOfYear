using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusineesLogic.Interface;
using System.Data.SqlClient;
using System.Configuration;
using BusineesLogic.factories;
using System.Data;
using BusineesLogic.domain;

namespace BusineesLogic.services
{
   public class TimeSheetDAO:ITimeSheet
    {
       private SqlConnection con;
       public TimeSheetDAO()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminBookingConnectionString"].ConnectionString);
        }

        public TimeSheetDTO getTimeSheet(DateTime date)
        {
            throw new NotImplementedException();
        }

        public bool ifTimeSheetExis(string id)
        {
            throw new NotImplementedException();
        }

        public int getTimesheetId(DateTime date)
        {
            throw new NotImplementedException();
        }

        public bool addTimeSheet(TimeSheetDTO model)
        {
            try
            {
                var Datetime = DateTime.Now;

                con.Open();
                string insertQuery = "INSERT INTO TimeSheet (DateWorked,HourIn,HourOut,EmployeeID) VALUES ('" + model.date + "','" + model.hourIn + "','" + model.hourOut + "','" + model.employeeId + "')";
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
                string updateQuery = "Update TimeSheet Set DateWorked= '" + model.date + "',HourIn='" + model.hourIn + "',HourOut='" + model.hourOut + "',EmployeeID='" + model.employeeId + "' Where Id ='" + model.id+ "'";
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
            try
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
                                       .buildDate(reader.GetDateTime(1))
                                       .buildHourIn(reader.GetInt32(2))
                                       .buildHourOut(reader.GetInt32(3))
                                       .buildEmployeeID(reader.GetInt32(4))
                                       .build();

                }
                con.Close();
                return timeSheet;
            }
            catch (Exception e)
            {
                return null;
            }


        }
    }
}
