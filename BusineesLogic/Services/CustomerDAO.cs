using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BusineesLogic.Interface;
using BusineesLogic.repositories.Impl;
using BusineesLogic.domain;

/// <summary>
/// Summary description for CustomerDAO
/// </summary>
public class CustomerDAO:ICustomers
{
    
    private CustomerRepositoryImpl repo = new CustomerRepositoryImpl();
    public CustomerDAO() { }
    public void save(CustomerDTO custDTO)
    {
        repo.save(custDTO);
    }
    public CustomerDTO getCustomerID(int number)
    {
        return repo.findByID(number);
        
    }
    public CustomerDTO getLastReocrd()//last customer
    {
        return repo.getLastReocrd();
    }
    public DataTable getAllCustomers()
    {
        return repo.getAllCustomers();
    }
    public DataTable populateGrid()
    {
        return repo.findAll();
    }
    public void delete(string id)
    {
        repo.delete(Convert.ToInt32(id));
    }

    public void update(string id,List<string> customer)
    {
        repo.updateCustomer(id, customer);
    }
    public DataTable searchCustomer(string id)
    {
        return repo.searchCustomer(id);
    }
}