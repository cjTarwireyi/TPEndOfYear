using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Supplier
/// </summary>
public class SupplierDTO
{
	public SupplierDTO()
	{

	}
    public int supplierNumber { set; get; }
    public String supplierName { set; get; }
    public String supplierSurname { set; get; }
    public String supplierCellNumber { set; get; }
    public String supplierStreetName { set; get; }
    public String supplierSuburb { set; get; }
    public String supplierPostalCode { set; get; }
}