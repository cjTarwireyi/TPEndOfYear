using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.repositories.Impl;

namespace UnitTests.repositories
{
    [TestClass]
    public class TestProductRepository
    {
        private Products result;
        private ProductRepositoryImpl repo = new ProductRepositoryImpl();

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
            repo.save(product);
            result = repo.getLastReocrd();
            int id = result.productNumber;
            Assert.IsNotNull(result);


            //update
            Products updateProduct = new Products.ProductsBuilder()
                                                  .copy(result)
                                                  .prodName("Samsung")
                                                  .build();

            repo.update(updateProduct);
            result = repo.findByID(id);


            //delete
            repo.delete(id);
            result = repo.findByID(id);
            Assert.IsNull(result);
        }
    }
}
