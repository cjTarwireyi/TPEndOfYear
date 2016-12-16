using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.factories;
namespace UnitTests.Repos
{
    [TestClass]
    public class OrderTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            IOder orderService = new OrdersDAO();
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
            orderService.AddOrder(order);
            //INSERTING ORDER
           OrderDTO addedOrder= orderService.getLastReocrd();
           Assert.AreEqual(30, addedOrder.amount);
           Assert.AreEqual(true, addedOrder.payed);

            //TESTING UPDATE
           OrderDTO updateOrder = new OrderDTO.OrderBuilder()
           
           .copy(addedOrder)
           .buildAmount(40)
           .build();

            //TESTING DELETE
             orderService.deleteOrder(addedOrder.orderId);
             OrderDTO deletedOrder = orderService.getOrderByID(addedOrder.orderId);
             Assert.IsNull(deletedOrder);

             
        }
    }
}
