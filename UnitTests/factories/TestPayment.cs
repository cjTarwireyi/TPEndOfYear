using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.domain;

namespace UnitTests.factories
{
    [TestClass]
    public class TestPayment
    {
        [TestMethod]
        public void testMakePayement()
        {
            PaymentDTO payment = PaymentFactory.makePayment((decimal)100,(decimal)200);
            Assert.AreEqual(payment.due,(decimal)100);

        }
    }
}
