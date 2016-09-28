using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Employee
/// </summary>
public class Employee
{
	public Employee()
	{
		
	}
    public int employeeNumber { set; get; }
    public String employeeName { set; get; }
    public String eployeeSurname { set; get; }
    public String employeeCellNumber { set; get; }
    public DateTime dateHired { set; get; }
    public Address address { set; get; }
}