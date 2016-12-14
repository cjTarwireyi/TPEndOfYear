using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.factories;
using BusineesLogic.domain;
namespace UnitTests.domain
{
    [TestClass]
    public class TestCategory
    {
        [TestMethod]
        public void TestCategoryDTO()
        {
            //CREATE
            CategoryDTO createCategory =  CategoryFactory.create("test", "test", DateTime.Parse("1/1/1900 12:00:00 AM"));
            Assert.AreEqual("test", createCategory.name);
            Assert.AreEqual("test", createCategory.description);
            Assert.AreEqual(DateTime.Parse("1/1/1900 12:00:00 AM"), createCategory.dateCreated);


            //UPDATE
            CategoryDTO updateCategory = new CategoryDTO.CategoryBuilder()
            .copy(createCategory)
            .buildDescription("update category")
            .build();
            Assert.AreEqual("update category", updateCategory.description);
            Assert.AreEqual(createCategory.name, updateCategory.name);
        }
    }
}
