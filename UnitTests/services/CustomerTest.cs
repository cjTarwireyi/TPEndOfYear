using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.domain;
using System.Collections.Generic;

namespace UnitTests.Repos
{
    [TestClass]
    public class CustomerTest
    {
        private CustomerDAO service = new CustomerDAO();
        private CustomerDTO result;

        [TestMethod]
        public void RetrieveCustomerTest()
        {
            result = service.getCustomerID(4);
            Assert.AreEqual(result.name.Trim(), "Shahiem");
            Assert.AreEqual(result.postalCode.Trim(), "7798");
            Assert.AreEqual(result.StreetName.Trim(), "Spitzway");
            Assert.AreEqual(result.Suburb.Trim(), "Strandforntien");
            Assert.AreEqual(result.surname.Trim(), "Wilkinson");
            Assert.AreEqual(result.cellNumber.Trim(), "(073)236-6146");
            Assert.AreEqual(result.email.Trim(), "siraajw19@gmail.com");
            Assert.AreEqual(result.customerNumber, 4);
        }

        [TestMethod]
        public void testInsertUpdateDeleteCustomer()
        {
            List<string> customerDetails = new List<string>();
            DateTime now = DateTime.Now;
            customerDetails.Add("Siraaj");
            customerDetails.Add("Wilkinson");
            customerDetails.Add("0783588370");
            customerDetails.Add("15 Sparrow");
            customerDetails.Add("Rocklands");
            customerDetails.Add("7798");
            customerDetails.Add("siraajw19@gmail.com");
            customerDetails.Add(now.ToString());
            CustomerDTO customer = CustomerFactory.getCustomer(1, customerDetails);

            //insert data
            service.save(customer);

            result = service.getLastReocrd();
            Assert.IsNotNull(result);

            int id = result.customerNumber;

           //update
            CustomerDTO updateCustomer = new CustomerDTO.CustomerBuilder()
                                                        .copy(result)
                                                        .custName("Shireen")
                                                        .build();
            

            
            service.updateCustomer(updateCustomer);
            result = service.getCustomerID(id);

            //Assert.AreEqual(result.name.Trim(), "Shireen");

            //delete
            service.delete(id.ToString());
            result = service.getCustomerID(id);

            Assert.IsNull(result);
        }

    }
}
