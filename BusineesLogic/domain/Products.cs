using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Products
/// </summary>
public class Products
{
	

    public int productNumber { set; get; }
    public string productName { set; get; }
    public string productDescription { set; get; }
    public int productQuantity { set; get; }
    public decimal price { set; get; }
    public int productSupplierID { set; get; }

    public bool productStatus { set; get; }
    public string dateArrived { set; get; }

    public Products()
    {

    }

    public Products(ProductsBuilder product)
    {
        this.productNumber = product.productNumber;
        this.productName = product.productName;
        this.productDescription = product.productDescription;
        this.productQuantity = product.productQuantity;
        this.price = product.price;
        this.productSupplierID = product.productSupplierID;
        this.productStatus = product.productStatus;
        this.dateArrived = product.dateArrived;
    }



    public class ProductsBuilder
    {
        public int productNumber;
        public string productName; 
        public string productDescription;
        public int productQuantity ;
        public decimal price;
        public int productSupplierID; 
        public bool productStatus;
        public string dateArrived;


        public ProductsBuilder prodNumber(int productNumber)
        {
            this.productNumber = productNumber;
            return this;
        }

        public ProductsBuilder prodName(string productName)
        {
            this.productName = productName;
            return this;
        }

        public ProductsBuilder prodDescription(string productDescription)
        {
            this.productDescription = productDescription;
            return this;
        }

        public ProductsBuilder prodQuantity(int productQuantity)
        {
            this.productQuantity = productQuantity;
            return this;
        }

        public ProductsBuilder prodPrice(decimal price)
        {
            this.price = price;
            return this;
        }

        public ProductsBuilder prodSupplierID(int productSupplierID)
        {
            this.productSupplierID = productSupplierID;
            return this;
        }

        public ProductsBuilder prodStatus(bool productStatus)
        {
            this.productStatus = productStatus;
            return this;
        }

        public ProductsBuilder prodDateArrived(string dateArrived)
        {
            this.dateArrived = dateArrived;
            return this;
        }


        public ProductsBuilder copy(Products product)
        {
            this.productName = product.productName;
            this.productDescription = product.productDescription;
            this.productQuantity = product.productQuantity;
            this.price = product.price;
            this.productSupplierID = product.productSupplierID;
            this.productStatus = product.productStatus;
            this.dateArrived = product.dateArrived;
            return this;
        }

        public Products build()
        {
            return new Products(this);
        }


    }



}