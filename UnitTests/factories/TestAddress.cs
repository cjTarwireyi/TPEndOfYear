using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BusineesLogic.factories;

namespace UnitTests.factories
{
    [TestClass]
    public class TestAddress
    {
        [TestMethod]
        public void testCreateAddress()
        {
            List<string> AddressDetails = new List<string>();
            AddressDetails.Add("Sparrow");
            AddressDetails.Add("Rocklands");
            AddressDetails.Add("7798");
            Address address = AddressFactory.createAddress(AddressDetails);

            Assert.AreEqual(address.streetName, "Sparrow");
        }


        [TestMethod]
        public void testUpdateAddress()
        {
            List<string> AddressDetails = new List<string>();
            AddressDetails.Add("Sparrow");
            AddressDetails.Add("Rocklands");
            AddressDetails.Add("7798");
            Address address = AddressFactory.createAddress(AddressDetails);
            Address updateAddress = new Address.AddressBuilder()
                        .copy(address)
                        .buildStreet("Spitzway")
                        .build();

            Assert.AreNotEqual(address.streetName, updateAddress.streetName);
        }
    }
}
