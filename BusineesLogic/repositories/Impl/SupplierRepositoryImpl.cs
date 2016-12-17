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
    public class SupplierRepositoryImpl : SupplierRepository
    {

        private SqlConnection con;
        public SupplierRepositoryImpl()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminBookingConnectionString"].ConnectionString);
        }

        public void save(SupplierDTO entity)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Suppliers([SupplierName], [SupplierSurname], [SupplierCellNumber], [SupplierStreetName],[SupplierSuburb],[SupplierPostalCode])values('" + entity.supplierName.Trim() + "','" + entity.supplierSurname.Trim() + "','" + entity.supplierCellNumber.Trim() + "','" + entity.supplierStreetName.Trim() + "','" + entity.supplierSuburb.Trim() + "','" + entity.supplierPostalCode.Trim() + "')";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void update(SupplierDTO entity)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update suppliers set supplierName ='" + entity.supplierName + "', supplierSurname='" + entity.supplierSurname + "',supplierCellNumber='" + entity.supplierCellNumber + "',supplierStreetName='" + entity.supplierStreetName + "',supplierSuburb='" + entity.supplierSuburb + "',supplierPostalCode='" + entity.supplierPostalCode + "' where supplierID = '" + entity.supplierNumber + "' ";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void delete(int id)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from suppliers where supplierID = '" + id + "' ";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public System.Data.DataTable findAll()
        {
            DataTable supplier = new DataTable();
            string query = "select * from suppliers order by supplierID DESC ";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(supplier);
            da.Dispose();
            con.Close();
            return supplier;
        }

        public SupplierDTO findByID(int id)
        {
            con.Open();
            String selectProduct = "select * from Suppliers where SupplierID =" + id + " ";
            SqlCommand myComm = new SqlCommand(selectProduct, con);
            SqlDataReader myDR;
            myDR = myComm.ExecuteReader();
            if (!myDR.Read())
                return null;
            SupplierDTO updateSupplier = makeSupplierDTO(myDR);
            con.Close();

            return updateSupplier;
        }

        public SupplierDTO makeSupplierDTO(SqlDataReader myDR)
        {
            SupplierDTO supplier = new SupplierDTO.SupplierBuilder()
            .supNumber(myDR.GetInt32(0))
            .supName(myDR.GetString(1))
            .supSurname(myDR.GetString(2))
            .supCellNumber(myDR.GetString(3))
            .supAddress(myDR.GetString(4), myDR.GetString(5), myDR.GetString(6))
            .build();
            return supplier;
        }


        public void updateSupplier(string id, List<string> supplierDetails)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update suppliers set supplierName ='" + supplierDetails[0] + "', supplierSurname='" + supplierDetails[1] + "',supplierCellNumber='" + supplierDetails[2] + "',supplierStreetName='" + supplierDetails[3] + "',supplierSuburb='" + supplierDetails[4] + "',supplierPostalCode='" + supplierDetails[5] + "' where supplierID = '" + id + "' ";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable searchSupplier(string id)
        {
            DataTable supplier = new DataTable();
            string query = "select * from suppliers where supplierID ='" + id + "' ";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(supplier);
            da.Dispose();
            con.Close();
            return supplier;
        }

        public SupplierDTO getLastReocrd()//last customer
        {
            SupplierDTO supplier = null;
            con.Open();
            String selectCustomer = "SELECT TOP 1 * FROM  suppliers Order by supplierID DESC ";
            SqlCommand myComm = new SqlCommand(selectCustomer, con);
            SqlDataReader myDR;
            myDR = myComm.ExecuteReader();
            if (myDR.Read())
                supplier = makeSupplierDTO(myDR);
            con.Close();
            return supplier;
        }

    }
}
