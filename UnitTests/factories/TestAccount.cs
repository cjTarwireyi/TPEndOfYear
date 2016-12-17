using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BusineesLogic.factories;
using BusineesLogic.domain;

namespace UnitTests.factories
{
    [TestClass]
    public class TestAccount
    {
        [TestMethod]
        public void testCreateAccount()
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
            AccountDTO account = AccountFactory.createAccount(customer);

            Assert.IsNotNull(account);
        }

        [TestMethod]
        public void testUpdateAccount()
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
            CustomerDTO updateCustomer = new CustomerDTO.CustomerBuilder()
                                                        .copy(customer)
                                                        .custName("Shireen")
                                                        .build();
            
            AccountDTO account = AccountFactory.createAccount(customer);
            AccountDTO updateAccount = new AccountDTO.AccountBuilder()
                                                     .copy(account)
                                                     .buildCustomer(updateCustomer)
                                                     .build();

            Assert.AreEqual(account.customer.surname,updateAccount.customer.surname);
            Assert.AreNotEqual(account.customer.name, updateAccount.customer.name);
        }


    }
}
