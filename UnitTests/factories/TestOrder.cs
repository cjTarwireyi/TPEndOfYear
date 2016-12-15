using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.factories;

namespace UnitTests.factories
{
    [TestClass]
    public class TestOrder
    {
        [TestMethod]
        public void createOrderTest()
        {
            //CREATE
            Products product = new Products() ;
            Products product2 = new Products();
            decimal amt= 0;
            List<Products> prodList = new List<Products>();
            product.productName = "test product";
            product.productQuantity = 2;
            product.productStatus = true;
            product.price = 20;
            amt += product.price;
            prodList.Add(product);

            product2.productName = "Cap";
            product2.productQuantity = 0;
            product2.productStatus = false;
            product2.price = 10;
            amt += product2.price;
            prodList.Add(product2);

            OrderDTO order = OrderFactory.createOrder(1, 1, amt ,true, prodList);

            Assert.AreEqual(30, order.amount);
            Assert.AreEqual(true, order.payed);

            //UPDATE
            OrderDTO updateOrder = new OrderDTO.OrderBuilder()
                .copy(order)
                .buildAmount(200)
                .build();
            Assert.AreNotEqual(order.amount, updateOrder.amount);


        }
    }
}
