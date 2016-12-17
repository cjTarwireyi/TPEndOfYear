using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BusineesLogic.Interface;
using BusineesLogic.domain;
using BusineesLogic.repositories.Impl;
 

/// <summary>
/// Summary description for EmployeeDAO
/// </summary>
public class EmployeeDAO
{
    private EmployeeRepositoryImpl repo = new EmployeeRepositoryImpl();
    public EmployeeDAO() { }
    public void save(EmployeeDTO emp)
    {
        repo.save(emp);
    }

    public void updateEmployee(EmployeeDTO emp)
    {
        repo.update(emp);
    }

    public void saveHoliday(HolidaysDTO emp,string id)
    {
        repo.saveHoliday(emp, id);
    }

    public EmployeeDTO getEmployee(int id)
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

    public void update(string id, List<string> employee)
    {
        repo.updateEmployee(id, employee);
    }

    public DataTable getHolidayInfo(string id)
    {
        return repo.getHolidayInfo(id);
    }

    public DataTable searchEmployee(string id)
    {
        return repo.searchEmployee(id);
    }

    public EmployeeDTO getLastRecrd()
    {
        return repo.getLastReocrd();
    }

    
}