using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CustomerDTO
/// </summary>
/// 
namespace BusineesLogic.domain
{

    public class CustomerDTO
    {
        public CustomerDTO()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public CustomerDTO(CustomerBuilder customerBuilder)
        {
            customerNumber = customerBuilder.customerNumber;
            name = customerBuilder.name;
            surname = customerBuilder.surname;
            cellNumber = customerBuilder.cellNumber;
            StreetName = customerBuilder.StreetName;
            Suburb = customerBuilder.Suburb;
            postalCode = customerBuilder.postalCode;
            email = customerBuilder.email;
            dateCreated = customerBuilder.dateCreated;
        }

        public int customerNumber { set; get; }
        public string name { set; get; }
        public string surname { set; get; }
        public string cellNumber { set; get; }
        public string StreetName { set; get; }
        public string Suburb { set; get; }
        public string postalCode { set; get; }
        public string dateCreated { set; get; }
        public string email { get; set; }

        public class CustomerBuilder
        {
            public int customerNumber;
            public string name;
            public string surname;
            public string cellNumber;
            public string StreetName;
            public string Suburb;
            public string postalCode;
            public string dateCreated;
            public string email;
            public CustomerBuilder custNumber(int customerNumber)
            {
                this.customerNumber = customerNumber;
                return this;
            }

            public CustomerBuilder custName(string name)
            {
                this.name = name;
                return this;
            }

            public CustomerBuilder custSurname(string surname)
            {
                this.surname = surname;
                return this;
            }

            public CustomerBuilder custCellNumber(string cellNumber)
            {
                this.cellNumber = cellNumber;
                return this;
            }

            public CustomerBuilder custAddress(string StreetName, string Suburb, string postalCode)
            {
                this.StreetName = StreetName;
                this.Suburb = Suburb;
                this.postalCode = postalCode;
                return this;
            }

            public CustomerBuilder custEmail(string email)
            {
                this.email = email;
                return this;
            }

            public CustomerBuilder accountCreatedDate(string dateAccountCreated)
            {
                this.dateCreated = dateAccountCreated;
                return this;
            }

            public CustomerBuilder copy(CustomerDTO customer)
            {
                this.name = customer.name;
                this.surname = customer.surname;
                this.cellNumber = customer.cellNumber;
                this.StreetName = customer.StreetName;
                this.Suburb = customer.Suburb;
                this.postalCode = customer.postalCode;
                this.email = customer.email;
                this.dateCreated = customer.dateCreated;
                return this;
            }

            public CustomerDTO build()
            {
                return new CustomerDTO(this);
            }
        }
    }
}