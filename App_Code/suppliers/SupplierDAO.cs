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
public class SupplierDAO
{
    private SqlConnection con;
	public SupplierDAO()
	{
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminBookingConnectionString"].ConnectionString);
	}

    public void save(SupplierDTO supplier)
    {
        //try
        //{
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
             cmd.CommandText = "insert into Suppliers([SupplierName], [SupplierSurname], [SupplierCellNumber], [SupplierStreetName],[SupplierSuburb],[SupplierPostalCode])values('" + supplier.supplierName.Trim() + "','" + supplier.supplierSurname.Trim() + "','" + supplier.supplierCellNumber.Trim() + "','" + supplier.supplierStreetName.Trim() + "','" + supplier.supplierSuburb.Trim() + "','" + supplier.supplierPostalCode.Trim() + "')";
            cmd.ExecuteNonQuery();
            con.Close();
        //}
        //catch (Exception e)
        //{
        //}
        //finally
        //{
        //    con.Close();
        //}
    }

    public SupplierDTO makeSupplierDTO(SqlDataReader myDR)
    {
       SupplierDTO supplier = new SupplierDTO();
        supplier.supplierNumber = myDR.GetInt32(0);
        supplier.supplierName = myDR.GetString(1);
        supplier.supplierSurname = myDR.GetString(2);
        supplier.supplierCellNumber = myDR.GetString(3);
        supplier.supplierStreetName = myDR.GetString(4);
        supplier.supplierSuburb = myDR.GetString(5);
        supplier.supplierPostalCode = myDR.GetString(6);
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
}