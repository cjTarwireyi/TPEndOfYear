using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Repos
{
    [TestClass]
    public class ProductTest
    {
        private ProductDAO service = new ProductDAO();
        private Products result;
        [TestMethod]
        public void testRetrieveProductTest()
        {
            result = service.getProduct(1);
            Assert.IsTrue(result.productStatus);

        }

        [TestMethod]
        public void testInsertUpdateDeleteProduct()
        {
            Products product = new Products.ProductsBuilder()
            .prodName("Iphone")
            .prodDescription("Sliver 16GB 6S")
            .prodQuantity(5)
            .prodPrice((decimal)12000.00)
            .prodStatus(true)
            .prodSupplierID(3)
            .build();

            //insert 
            service.save(product);
            result = service.getLastReocrd();
            int id = result.productNumber;
            Assert.IsNotNull(result);


            //update
            Products updateProduct = new Products.ProductsBuilder()
                                                  .copy(result)
                                                  .prodName("Samsung")
                                                  .build();

            service.updateProduct(updateProduct);
            result = service.getProduct(id);


            //delete
            service.delete(id.ToString());
            result = service.getProduct(id);
            Assert.IsNull(result);
        }
    }
}
