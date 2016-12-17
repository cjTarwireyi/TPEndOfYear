using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.repositories.Impl;
using System.Collections.Generic;
using BusineesLogic.factories;

namespace UnitTests.repositories
{
    [TestClass]
    public class TestOrderRepository
    {
        private OrderDTO result;
        private OrderRepositoryImpl repo = new OrderRepositoryImpl();

        [TestMethod]
        public void testInsertUpdateDeleteOrder()
        {  
            Products product = new Products();
            Products product2 = new Products();
            decimal amt = 0;
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

            OrderDTO order = OrderFactory.createOrder(1, 1, amt, true, prodList);

            //INSERTING ORDER
            repo.AddOrder(order);
            OrderDTO addedOrder = repo.getLastReocrd();
            Assert.AreEqual(30, addedOrder.amount);
            Assert.AreEqual(true, addedOrder.payed);

            //TESTING UPDATE
            OrderDTO updateOrder = new OrderDTO.OrderBuilder()

            .copy(addedOrder)
            .buildAmount(40)
            .build();

            //TESTING DELETE
            repo.deleteOrder(addedOrder.orderId);
            OrderDTO deletedOrder = repo.findByID(addedOrder.orderId);
            Assert.IsNull(deletedOrder);

        }
    }
}
