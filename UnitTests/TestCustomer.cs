using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace UnitTesting.factories
{
    [TestClass]
    public class TestCustomer
    {
        [TestMethod]
        public void createCustomerTest()
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
            CustomerDTO customer = CustomerFactory.getCustomer(1,customerDetails);
            Assert.AreEqual(customer.name,"Siraaj");
        }
    }
}
