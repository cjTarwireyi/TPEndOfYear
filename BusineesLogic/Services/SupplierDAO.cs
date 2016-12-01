using BusineesLogic.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SupplierDAO
/// </summary>
public class SupplierDAO : IDatabaseFunctions
{
    private SqlConnection con;
    public SupplierDAO()
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminBookingConnectionString"].ConnectionString);
    }

    public void save(SupplierDTO supplier)
    {

        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "insert into Suppliers([SupplierName], [SupplierSurname], [SupplierCellNumber], [SupplierStreetName],[SupplierSuburb],[SupplierPostalCode])values('" + supplier.supplierName.Trim() + "','" + supplier.supplierSurname.Trim() + "','" + supplier.supplierCellNumber.Trim() + "','" + supplier.supplierStreetName.Trim() + "','" + supplier.supplierSuburb.Trim() + "','" + supplier.supplierPostalCode.Trim() + "')";
        cmd.ExecuteNonQuery();
        con.Close();
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

    public SupplierDTO getSupplier(int id)
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

    public DataTable populateGrid()
    {
        DataTable supplier = new DataTable();
        string query = "select * from suppliers";
        con.Open();
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(supplier);
        da.Dispose();
        con.Close();
        return supplier;
    }

    public void delete(string id)
    {
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "delete from suppliers where supplierID = '" + id + "' ";
        cmd.ExecuteNonQuery();
        con.Close();
    }

    public void update(string id, List<string> supplierDetails)
    {
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "update suppliers set supplierName ='" + supplierDetails[0] + "', supplierSurname='" + supplierDetails[1] + "',supplierCellNumber='" + supplierDetails[2] + "',supplierStreetName='" + supplierDetails[3] + "',supplierSuburb='" + supplierDetails[4] + "',supplierPostalCode='" + supplierDetails[5] + "' where supplierID = '" + id + "' ";
        cmd.ExecuteNonQuery();
        con.Close();
    }

}