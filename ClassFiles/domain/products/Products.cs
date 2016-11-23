using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Products
/// </summary>
public class Products
{
	public Products()
	{
		
	}

    public int productNumber { set; get; }
    public String productName { set; get; }
    public String productDescription { set; get; }
    public int productQuantity { set; get; }
    public decimal price { set; get; }
    public int productSupplierID { set; get; }

    public Boolean productStatus { set; get; }
    public DateTime dateArrived { set; get; }

}