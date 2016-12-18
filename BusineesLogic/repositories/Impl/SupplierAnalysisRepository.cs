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
    public class SupplierAnalysisRepository : ISupplierAnalysisRepository
    {
        private SqlConnection con;
        public SupplierAnalysisRepository()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminBookingConnectionString"].ConnectionString);
        }
        public void save(SuplierAnalysisDTO entity)
        {
            try
            {
                if (con.State.ToString() == "Open")
                    con.Close();
                var Datetime = DateTime.Now;

                con.Open();
                string insertQuery = "INSERT INTO SupplierAnalysis (Description,ProductId,DateSupplied) VALUES ('" + entity.description + "','" + entity.productId + "','" + entity.dateModified + "')";
                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.ExecuteNonQuery();

                con.Close();


            }
            catch (Exception e)
            {

            }

        }

        public void update(SuplierAnalysisDTO entity)
        {
            try
            {
                if (con.State.ToString() == "Open")
                    con.Close();

                con.Open();
                string updateQuery = "Update SupplierAnalysis Set Description= '" + entity.description + "',ProductId='" + entity.productId + "',DateSupplied='" + entity.dateModified + "' Where Id ='" + entity.id + "'";
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
                if (con.State.ToString() == "Open")
                    con.Close();

                con.Open();
                string deleteQuery = "DELETE FROM SupplierAnalysis WHERE  Id ='" + id + "'";
                SqlCommand cmd = new SqlCommand(deleteQuery, con);
                cmd.ExecuteNonQuery();

                con.Close();

            }
            catch (Exception e)
            {

            }
        }

        public System.Data.DataTable findAll()
        {
            DataTable data = new DataTable();

            string query = "select * from SupplierAnalysis order by id DESC";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(data);
            da.Dispose();
            con.Close();
            return data;
        }

        public SuplierAnalysisDTO findByID(int id)
        {
            if (con.State.ToString() == "Open")
                con.Close();

            SuplierAnalysisDTO data = null;
            con.Open();
            String querry = "SELECT TOP 1 * FROM  SupplierAnalysis Where Id='" + id + "' ";
            SqlCommand myComm = new SqlCommand(querry, con);
            SqlDataReader myDR;
            myDR = myComm.ExecuteReader();
            if (myDR.Read())
            {
                data = new SuplierAnalysisDTO.SupplierAnalysisBuilder()
                    .buildId(myDR.GetInt32(0))
                    .buildDescription(myDR.GetString(1))
                    .buildDateModified(myDR.GetDateTime(2))
                    .buildProductId(myDR.GetInt32(3))
                    .build();
            }
            else
            {
                data = null;
            }
            con.Close();
            return data;
        }
        public SuplierAnalysisDTO getLastReocrd()
        {
            if (con.State.ToString() == "Open")
                con.Close();

            SuplierAnalysisDTO data = null;
            con.Open();
            String querry = "SELECT TOP 1 * FROM  SupplierAnalysis Order by Id DESC "; 
            SqlCommand myComm = new SqlCommand(querry, con);
            SqlDataReader myDR;
            myDR = myComm.ExecuteReader();
            if (myDR.Read())
            {
                data = new SuplierAnalysisDTO.SupplierAnalysisBuilder()
                    .buildId(myDR.GetInt32(0))
                    .buildDescription(myDR.GetString(1))
                    .buildDateModified(myDR.GetDateTime(2))
                    .buildProductId(myDR.GetInt32(3))
                    .build();
            }
            else
            {
                data = null;
            }
            con.Close();
            return data;
        }
    }
}
