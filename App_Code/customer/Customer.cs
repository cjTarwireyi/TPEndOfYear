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
    public String StreetName { set; get; }
    public String Suburb { set; get; }
    public String postalCode { set; get; }

    public String email { set; get; }
}