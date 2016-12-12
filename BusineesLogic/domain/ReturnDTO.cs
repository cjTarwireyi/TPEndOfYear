using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.domain
{
    public class ReturnDTO
    {
        public int productID { get; set; }
        public int orderID { get; set; }
        public int customerID { get; set; }
        public string reason { get; set; }
        public string dateReturned { get; set; }
        public int quantity { get; set; }

        private ReturnDTO() { }
        public ReturnDTO( ReturnBuilder itemReturned)
        {
            this.productID = itemReturned.productID;
            this.orderID = itemReturned.orderID;
            this.customerID = itemReturned.customerID;
            this.reason = itemReturned.reason;
            this.dateReturned = itemReturned.dateReturned;
            this.quantity = itemReturned.quantity;
        }
         public class ReturnBuilder
         {
             public int productID;
             public int orderID;
             public int customerID;
             public string reason;
             public string dateReturned;
             public int quantity;
             public ReturnBuilder productNumber(int productID)
             {
                 this.productID = productID;
                 return this;
             }
             public ReturnBuilder orderNumber(int orderID)
             {
                 this.orderID = orderID;
                 return this;
             }
             public ReturnBuilder customerNumber(int customerID)
             {
                 this.customerID = customerID;
                 return this;
             }
             public ReturnBuilder customerReason(string reason)
             {
                 this.reason = reason;
                 return this;
             }

             public ReturnBuilder productQuantity(int quantity)
             {
                 this.quantity = quantity;
                 return this;
             }
             public ReturnBuilder date(string dateReturned)
             {
                 this.dateReturned = dateReturned;
                 return this;
             }
             public ReturnBuilder copy(ReturnDTO itemReturned)
             {
                 this.productID = itemReturned.productID;
                 this.orderID = itemReturned.orderID;
                 this.customerID = itemReturned.customerID;
                 this.reason = itemReturned.reason;
                 this.dateReturned = itemReturned.dateReturned;
                 this.quantity = itemReturned.quantity;
                 return this;
             }
             public ReturnDTO build()
             {
                 return new ReturnDTO(this);
             }
         }
    }
}
