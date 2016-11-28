using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Supplier
/// </summary>
public class SupplierDTO
{
	
    public int supplierNumber { set; get; }
    public string supplierName { set; get; }
    public string supplierSurname { set; get; }
    public string supplierCellNumber { set; get; }
    public string supplierStreetName { set; get; }
    public string supplierSuburb { set; get; }
    public string supplierPostalCode { set; get; }

    //Constructors 
    public SupplierDTO()
    {

    }
    public SupplierDTO(SupplierBuilder supplier)
    {
        this.supplierNumber = supplier.supplierNumber;
        this.supplierName = supplier.supplierName;
        this.supplierSurname = supplier.supplierSurname;
        this.supplierCellNumber = supplier.supplierCellNumber;
        this.supplierStreetName = supplier.supplierStreetName;
        this.supplierSuburb = supplier.supplierSuburb;
        this.supplierPostalCode = supplier.supplierPostalCode;
    }


    public class SupplierBuilder
    {
        public int supplierNumber; 
        public string supplierName; 
        public string supplierSurname; 
        public string supplierCellNumber; 
        public string supplierStreetName;
        public string supplierSuburb;
        public string supplierPostalCode;

        public SupplierBuilder supNumber(int supplierNumber)
        {
            this.supplierNumber = supplierNumber;
            return this;
        }

        public SupplierBuilder supName(string supplierName)
        {
            this.supplierName = supplierName;
            return this;
        }

        public SupplierBuilder supSurname(string supplierSurname)
        {
            this.supplierSurname = supplierSurname;
            return this;
        }

        public SupplierBuilder supCellNumber(string supplierCellNumber)
        {
            this.supplierCellNumber = supplierCellNumber;
            return this;
        }

        public SupplierBuilder supAddress(string supplierStreetName, string supplierSuburb,string supplierPostalCode)
        {
            this.supplierStreetName = supplierStreetName;
            this.supplierSuburb = supplierSuburb;
            this.supplierPostalCode = supplierPostalCode;
            return this;
        }

        public SupplierBuilder copy(SupplierDTO supplier)
        {
            this.supplierName = supplier.supplierName;
            this.supplierSurname = supplier.supplierSurname;
            this.supplierCellNumber = supplier.supplierCellNumber;
            this.supplierStreetName = supplier.supplierStreetName;
            this.supplierSuburb = supplier.supplierSuburb;
            this.supplierPostalCode = supplier.supplierPostalCode;
            return this;
        }
        public SupplierDTO build()
        {
            return new SupplierDTO(this);
        }
    }
}