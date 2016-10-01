using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Supplier
/// </summary>
public class Supplier
{
	public Supplier()
	{

	}
    public int supplierNumber { set; get; }
    public String supplierName { set; get; }
    public String supplierSurname { set; get; }
    public String supplierCellNumber { set; get; }
    public Address address { set; get; }
}