using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.factories;
using BusineesLogic.repositories;
using BusineesLogic.domain;
using BusineesLogic.services;
namespace UnitTests.services
{
    [TestClass]
    public class TestTransactionService
    {
        [TestMethod]
        public void TestTransactionServiceMethods()
        {
            TransactionDAO service = new TransactionDAO();
            //CREATE TEST
            DateTime date = DateTime.Parse("1/1/1900 12:00:00 AM");

            TransactionDTO transaction = TransactionFactory.create("123", 200, "cj", date);

            service.save(transaction);

            // Assert.AreEqual(DateTime.Parse("1/1/1900 12:00:00 AM"), repo.getLastReocrd().dateModified);
            Assert.AreEqual(200, service.getLastReocrd().amount);
            Assert.AreEqual("123", service.getLastReocrd().code.Trim());
            TransactionDTO found = service.getLastReocrd();
            //TEST UPDATE
            TransactionDTO update = new TransactionDTO.TransactionBuilder()
                .copy(service.getLastReocrd())
                .buildCode("444")
                .build();
            service.update(update);
            Assert.AreEqual("444", service.getLastReocrd().code.Trim());
            Assert.AreEqual(200, service.getLastReocrd().amount);
            // Assert.AreEqual(update.dateModified, repo.getLastReocrd().dateModified);

            service.delete(found.id);
            Assert.IsNull(service.findByID(found.id));
        }
    }
}
