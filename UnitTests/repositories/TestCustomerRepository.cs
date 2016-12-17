using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BusineesLogic.repositories.Impl;
using BusineesLogic.domain;

namespace UnitTests.repositories
{
    [TestClass]
    public class TestCustomerRepository
    {
        private CustomerRepositoryImpl repo = new CustomerRepositoryImpl();
        private CustomerDTO result;

        [TestMethod]
        public void testCreateCustomer()
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
            repo.save(customer);

            result = repo.getLastReocrd();
            Assert.IsNotNull(result);

            int id = result.customerNumber;

            //update
            CustomerDTO updateCustomer = new CustomerDTO.CustomerBuilder()
                                                        .copy(result)
                                                        .custName("Shireen")
                                                        .build();
            repo.update(updateCustomer);
            result = repo.findByID(id);

            //Assert.AreEqual(result.name.Trim(),"Shireen");

            //delete
            repo.delete(id);
            result = repo.findByID(id);

            Assert.IsNull(result);
        }

        
    }
}
