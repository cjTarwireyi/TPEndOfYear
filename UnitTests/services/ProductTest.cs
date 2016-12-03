using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Repos
{
    [TestClass]
    public class ProductTest
    {
        private ProductDAO product = new ProductDAO();
        private Products result;
        [TestMethod]
        public void RetrieveProductTest()
        {
            result = product.getProduct(1);
            Assert.IsTrue(result.productStatus);

        }
    }
}
