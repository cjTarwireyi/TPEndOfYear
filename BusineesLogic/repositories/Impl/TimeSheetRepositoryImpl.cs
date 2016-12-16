﻿using BusineesLogic.domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public System.Data.DataTable findAll()
        {
            throw new NotImplementedException();
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
                string updateQuery = "Update TimeSheet Set DateWorked= '" + model.date + "',HourIn='" + model.hourIn + "',HourOut='" + model.hourOut + "',EmployeeID='" + model.employeeId + "' Where Id ='" + model.id + "'";
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
                                   .buildDate(reader.GetDateTime(1))
                                   .buildHourIn(reader.GetInt32(2))
                                   .buildHourOut(reader.GetInt32(3))
                                   .buildEmployeeID(reader.GetInt32(4))
                                   .build();

            }
            con.Close();
            return timeSheet;

        }
    }
}