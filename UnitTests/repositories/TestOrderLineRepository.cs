using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.factories;
using BusineesLogic.repositories;
using BusineesLogic.domain;
using BusineesLogic.repositories.Impl;
using System.Collections.Generic;
namespace UnitTests.repositories
{
    [TestClass]
    public class TestOrderLineRepository
    {
        [TestMethod]
        public void TestOrdeLineRepo()
        {
            InterfaceOrderLine orderlineService = new OrderLineDAO();
            OrderLineDTO orderLineDTO = OrderLineFactory.createOrderLine(1, 1, 2);
            List<OrderLineDTO> lst = new List<OrderLineDTO>();
            lst.Add(orderLineDTO);
            orderlineService.AddOderLine(lst);
        
        }
    }
}
