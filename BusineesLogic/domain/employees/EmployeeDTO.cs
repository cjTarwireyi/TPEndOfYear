using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Employee
/// </summary>
public class EmployeeDTO
{
    public int employeeNumber { set; get; }
    public string employeeName { set; get; }
    public string employeeSurname { set; get; }
    public string employeeCellNumber { set; get; }
    public string dateHired { set; get; }
    public string employeeStreetName { set; get; }
    public string employeeSuburb { set; get; }
    public string employeePostalCode { set; get; }

    public EmployeeDTO()
    {

    }


    public EmployeeDTO(EmployeeBuilder employeeBuilder)
    {
        employeeNumber = employeeBuilder.employeeNumber;
        employeeName = employeeBuilder.employeeName;
        employeeSurname = employeeBuilder.employeeSurname;
        employeeCellNumber = employeeBuilder.employeeCellNumber;
        employeeStreetName = employeeBuilder.employeeStreetName;
        employeeSuburb = employeeBuilder.employeeSuburb;
        employeePostalCode = employeeBuilder.employeePostalCode;
        dateHired = employeeBuilder.dateHired;
       
    }

    public class EmployeeBuilder
    {
        public int employeeNumber;
        public string employeeName;
        public string employeeSurname;
        public string employeeCellNumber;
        public string dateHired;
        public string employeeStreetName;
        public string employeeSuburb;
        public string employeePostalCode;

        public EmployeeBuilder empNumber(int employeeNumber)
        {
            this.employeeNumber = employeeNumber;
            return this;
        }

        public EmployeeBuilder empName(string employeeName)
        {
            this.employeeName = employeeName;
            return this;
        }


        public EmployeeBuilder empSurname(string employeeSurname)
        {
            this.employeeSurname = employeeSurname;
            return this;
        }


        public EmployeeBuilder empCellNumber(string employeeCellNumber)
        {
            this.employeeCellNumber = employeeCellNumber;
            return this;
        }

        public EmployeeBuilder empAddress(string employeeStreetName,string employeeSuburb,string employeePostalCode)
        {
            this.employeeStreetName = employeeStreetName;
            this.employeeSuburb = employeeStreetName;
            this.employeePostalCode = employeePostalCode;
            return this;
        }

        public EmployeeBuilder empDateHired(string dateHired)
        {
            this.dateHired = dateHired;
            return this;
        }

        public EmployeeBuilder copy(EmployeeDTO employee)
        {
            this.employeeNumber = employee.employeeNumber;
            this.employeeName = employee.employeeName;
            this.employeeSurname = employee.employeeSurname;
            this.employeeCellNumber = employee.employeeCellNumber;
            this.employeeStreetName = employee.employeeStreetName;
            this.employeeSuburb = employee.employeeSuburb;
            this.employeePostalCode = employee.employeePostalCode;
            this.dateHired = employee.dateHired;
            return this;
        }

        public EmployeeDTO build()
        {
            return new EmployeeDTO(this);
        }


      
    }
}