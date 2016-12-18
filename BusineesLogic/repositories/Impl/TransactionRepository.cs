using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusineesLogic.repositories;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using BusineesLogic.domain;
namespace BusineesLogic.repositories.Impl
{
   public class TransactionRepository:ITransactionRepository 
    {
        private SqlConnection con;
        public TransactionRepository()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminBookingConnectionString"].ConnectionString);
        }
        public void save(domain.TransactionDTO entity)
        {
            try
            {
                if (con.State.ToString() == "Open")
                    con.Close();
                var Datetime = DateTime.Now;

                con.Open();
                string insertQuery = "INSERT INTO TransactionTable (TransCode,Amount,DateModified,TransUser) VALUES ('" + entity.code + "','" + entity.amount + "','" + DateTime.Now.ToString() + "','" + entity.dateModified + "')";
                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.ExecuteNonQuery();

                con.Close();


            }
            catch (Exception e)
            {

            }

        }

        public void update(domain.TransactionDTO entity)
        {
            try
            {
                if (con.State.ToString() == "Open")
                    con.Close();

                con.Open();
                string updateQuery = "Update TransactionTable Set TransCode= '" + entity.code + "',Amount='" + entity.amount + "',DateModified='" + entity.dateModified + "',TransUser='" + entity.transUser + "' Where Id ='" + entity.id + "'";
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
                string deleteQuery = "DELETE FROM TransactionTable WHERE  Id ='" + id + "'";
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

            string query = "select * from Transaction order by id DESC";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(data);
            da.Dispose();
            con.Close();
            return data;
        }

        public domain.TransactionDTO findByID(int id)
        {
            if (con.State.ToString() == "Open")
                con.Close();

            TransactionDTO data = null;
            con.Open();
            String querry = "SELECT TOP 1 * FROM  TransactionTable Where Id='" + id + "' ";
            SqlCommand myComm = new SqlCommand(querry, con);
            SqlDataReader myDR;
            myDR = myComm.ExecuteReader();
            if (myDR.Read())
            {
                data = new TransactionDTO.TransactionBuilder()
                    .buildId(myDR.GetInt32(0))
                    .buildCode(myDR.GetString(1))
                    .buildAmount(myDR.GetDecimal(2))
                    .buildDateModified(myDR.GetDateTime(3))
                    .buildTransUser(myDR.GetString(4))
                    .build();
            }
            else
            {
                data = null;
            }
            con.Close();
            return data;
        }
        public TransactionDTO getLastReocrd()
        {
            if (con.State.ToString() == "Open")
                con.Close();
            TransactionDTO data = null;
            con.Open();
            String querry = "SELECT TOP 1 * FROM  TransactionTable Order by Id DESC ";
            SqlCommand myComm = new SqlCommand(querry, con);
            SqlDataReader myDR;
            myDR = myComm.ExecuteReader();
            if (myDR.Read())
                data = new TransactionDTO.TransactionBuilder()
                    .buildId(myDR.GetInt32(0))
                    .buildCode(myDR.GetString(1))
                    .buildAmount(myDR.GetDecimal(2))
                    .buildDateModified(myDR.GetDateTime(3))
                    .buildTransUser(myDR.GetString(4))
                    .build();
            con.Close();
            return data;
        }
    }
}
