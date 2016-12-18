using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.factories;
using System.Collections.Generic;
namespace UnitTests.Repos
{
    [TestClass]
    public class OrderLineTest
    {
        [TestMethod]
        public void TestOrderLineService()
        {
            InterfaceOrderLine orderlineService = new OrderLineDAO() ;
            OrderLineDTO orderLineDTO = OrderLineFactory.createOrderLine(1, 1, 2);
            List<OrderLineDTO> lst = new List<OrderLineDTO>();
            lst.Add(orderLineDTO);
            orderlineService.AddOderLine(lst);
        }
    }
}
