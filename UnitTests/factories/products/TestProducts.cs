using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.factories
{
    [TestClass]
    public class TestProducts
    {
        [TestMethod]
        public void createProduct()
        {
            Products product = new Products.ProductsBuilder()
            .prodName("Iphone")
            .prodDescription("Sliver 16GB 6S")
            .prodQuantity(5)
            .prodPrice((decimal)12000.00)
            .prodStatus(true)
            .build();

            Assert.AreEqual(product.productName, "Iphone");
            Assert.IsTrue(product.productStatus);

        }
    }
}
