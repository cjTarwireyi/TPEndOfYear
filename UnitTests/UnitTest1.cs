using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            CustomerDTO customer = new CustomerDTO.CustomerBuilder()
           .custNumber(1)
           .custName("Shireen")
           .custSurname("Wilkinson")
           .custCellNumber("")
           .custEmail("")
           .custAddress("","","")
           .accountCreatedDate("")
           .build();

            Assert.AreEqual(customer.name, "Shireen");
        }
    }
}
