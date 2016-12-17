using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.domain;

namespace UnitTests.Repos
{
    [TestClass]
    public class CustomerTest
    {
        private CustomerDAO customer = new CustomerDAO();
        private CustomerDTO result;

        [TestMethod]
        public void RetrieveCustomerTest()
        {
            result = customer.getCustomerID(4);
            Assert.AreEqual(result.name.Trim(),"Shahiem");
            Assert.AreEqual(result.postalCode.Trim(), "7798");
            Assert.AreEqual(result.StreetName.Trim(),"Spitzway");
            Assert.AreEqual(result.Suburb.Trim(),"Strandforntien");
            Assert.AreEqual(result.surname.Trim(), "Wilkinson");
            Assert.AreEqual(result.cellNumber.Trim(), "(073)236-6146");
            Assert.AreEqual(result.email.Trim(),"siraajw19@gmail.com");
            Assert.AreEqual(result.customerNumber, 4);
        }

        [TestMethod]
        public void test()
        {
            
        }
    }
}
