using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Customer
/// </summary>
public class Customer
{
	public Customer()
	{
		
	}

    public int customerNumber { set; get; }
    public String name { set; get; }
    public String surname { set; get; }
    public String cellNumber { set; get; }
    public String streetName { set; get; }
    public String suburb { set; get; }
    public String postalCode { set; get; }
}