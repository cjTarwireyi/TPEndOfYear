using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Address
/// </summary>
public class Address
{
	public Address()
	{
		
	}

    public Address(AddressBuilder address)
    {
        this.suburb = address.suburb;
        this.streetName = address.streetName;
        this.postalCode = address.postalCode;
        
    }

    public string streetName;
    public string suburb;
    public string postalCode;

     public class AddressBuilder
     {
         public string streetName;
         public string suburb;
         public string postalCode;

         public AddressBuilder buildSuburb(string suburb)
         {
             this.suburb = suburb;
             return this;
         }

         public AddressBuilder buildStreet(string streetName)
         {
             this.streetName = streetName;
             return this;
         }

         public AddressBuilder buildPostalCode(string postalCode)
         {
             this.postalCode = postalCode;
             return this;
         }

         public AddressBuilder copy(Address address)
         {
             this.suburb = address.suburb;
             this.streetName = address.streetName;
             this.postalCode = address.postalCode;
             return this;
         }

         public Address build()
         {
             return new Address(this);
         }
     }
}