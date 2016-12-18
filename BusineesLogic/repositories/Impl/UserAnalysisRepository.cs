using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusineesLogic.repositories;
using System.Data.SqlClient;
using System.Configuration;
using BusineesLogic.domain;
using System.Data;
namespace BusineesLogic.repositories.Impl
{
   public class UserAnalysisRepository:IUserAnalysisRepository
    {
        private SqlConnection con;
        public UserAnalysisRepository()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminBookingConnectionString"].ConnectionString);
        }
        public void save(domain.UserAnalysisDTO entity)
        {
            try
            {
                if (con.State.ToString() == "Open")
                    con.Close();
                var Datetime = DateTime.Now;

                con.Open();
                string insertQuery = "INSERT INTO UserAnalysis (UserId,TimesAccessed,PageAccessed,DateAccessed) VALUES ('" + entity.userId + "','" + entity.timesAccessed + "','"+entity.pageAccessed+"','" + DateTime.Now.ToString() + "')";
                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.ExecuteNonQuery();

                con.Close();

                 
            }
            catch (Exception e)
            {
                 
            }
        }

        public void update(domain.UserAnalysisDTO entity)
        {
            try
            {
                con.Open();
                string updateQuery = "Update UserAnalysis Set UserId= '" + entity.userId + "',TimesAccessed='" + entity.timesAccessed + "',PageAccessed='"+entity.pageAccessed+"',DateAccessed='" + entity.dateModified + "' Where Id ='" +entity.id + "'";
                SqlCommand cmd = new SqlCommand(updateQuery, con);
                cmd.ExecuteNonQuery();
                con.Close();
                 
            }
            catch (Exception e)
            {
 
            }

        }

        public void delete(int id)
        {
            try
            {
                con.Open();
                string deleteQuery = "DELETE FROM UserAnalysis WHERE  Id ='" + id + "'";
                SqlCommand cmd = new SqlCommand(deleteQuery, con);
                cmd.ExecuteNonQuery();

                con.Close();
                 
            }
            catch (Exception e)
            {
                 
            }
        }

        public DataTable findAll()
        {
            DataTable data = new DataTable();
             
            string query = "select * from UserAnalysis order by id DESC";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(data);
            da.Dispose();
            con.Close();
            return data;
       
        }

        public domain.UserAnalysisDTO findByID(int id)
        {
            UserAnalysisDTO userAnalysis = null;
            con.Open();
            String querry = "SELECT TOP 1 * FROM  UserAnalysis Where Id='"+id+"' ";
            SqlCommand myComm = new SqlCommand(querry, con);
            SqlDataReader myDR;
            myDR = myComm.ExecuteReader();
            if (myDR.Read())
            {
                userAnalysis = new UserAnalysisDTO.UserAnalysisBuilder()
                    .buildId(myDR.GetInt32(0))
                    .buildUserId(myDR.GetInt32(1))
                    .buildTimesAccessed(myDR.GetInt32(2))
                    .buildPageAccessed(myDR.GetString(3))
                    .buildDateModified(myDR.GetDateTime(4))
                    .build();
            }
            else
            {
                userAnalysis = null;
            }
            con.Close();
            return userAnalysis;
        }
        public UserAnalysisDTO getLastReocrd( )
        {
            if (con.State.ToString() == "Open")
                con.Close();
            UserAnalysisDTO userAnalysis = null;
            con.Open();
            String querry = "SELECT TOP 1 * FROM  UserAnalysis Order by Id DESC ";
            SqlCommand myComm = new SqlCommand(querry, con);
            SqlDataReader myDR;
            myDR = myComm.ExecuteReader();
            if (myDR.Read())
                userAnalysis = new UserAnalysisDTO.UserAnalysisBuilder()
                    .buildId(myDR.GetInt32(0))
                    .buildUserId(myDR.GetInt32(1))
                    .buildTimesAccessed(myDR.GetInt32(2))
                    .buildPageAccessed(myDR.GetString(3))
                    .buildDateModified(myDR.GetDateTime(4))
                    .build();
            con.Close();
            return userAnalysis;
        }
    }
}
