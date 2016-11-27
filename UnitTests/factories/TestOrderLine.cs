using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.factories;
namespace UnitTests.factories
{
    [TestClass]
    public class TestOrderLine
    {
        [TestMethod]
        public void createOrderLine()
        {
            OrderLineDTO orderLine = OrderLineFactory.createOrderLine(1, 1, 20);

            Assert.AreEqual(1, orderLine.productID);
            Assert.AreEqual(1, orderLine.orderId);
            Assert.AreEqual(20, orderLine.quantity);
        }
    }
}
