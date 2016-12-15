using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.factories;
using BusineesLogic.domain;

namespace UnitTests.domain
{
    [TestClass]
    public class TestTransaction
    {
        [TestMethod]
        public void TestTransactionDTO()
        {
            //CREATE TEST
            DateTime date = DateTime.Parse("1/1/1900 12:00:00 AM");

            TransactionDTO transaction = TransactionFactory.create("123", 200, date);
            Assert.AreEqual(DateTime.Parse("1/1/1900 12:00:00 AM"), transaction.dateModified);
            Assert.AreEqual(200, transaction.amount);
            Assert.AreEqual("123", transaction.code);

            //TEST UPDATE
            TransactionDTO update = new TransactionDTO.TransactionBuilder()
                .copy(transaction)
                .buildCode("444")
                .build();
            Assert.AreEqual("444", update.code);
            Assert.AreEqual(update.amount, transaction.amount);
            Assert.AreEqual(update.dateModified, transaction.dateModified);
        }
    }
}
