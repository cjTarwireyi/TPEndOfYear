using BusineesLogic.Interface;
using BusineesLogic.repositories.Impl;
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
    private SupplierRepositoryImpl repo = new SupplierRepositoryImpl();
    public SupplierDAO() { }

    public void save(SupplierDTO supplier)
    {
        repo.save(supplier);
    }


    public SupplierDTO getSupplier(int id)
    {
        return repo.findByID(id);
    }

    public DataTable populateGrid()
    {
        return repo.findAll();
    }

    public void delete(string id)
    {
        repo.delete(Convert.ToInt32(id));
    }

    public void update(string id, List<string> supplierDetails)
    {
        repo.updateSupplier(id,supplierDetails);
    }

    public DataTable searchSupplier(string id)
    {
        return repo.searchSupplier(id);
    }
}