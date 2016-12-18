using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.factories;
using BusineesLogic.domain;
using BusineesLogic.repositories.Impl;
namespace UnitTests.repositories
{
    [TestClass]
    public class TestTransactionRepository
    {
        [TestMethod]
        public void TestTransactionRepo()
        {
            TransactionRepository repo = new TransactionRepository();
            //CREATE TEST
            DateTime date = DateTime.Parse("1/1/1900 12:00:00 AM");

            TransactionDTO transaction = TransactionFactory.create("123", 200, "cj", date);
            
            repo.save(transaction);

           // Assert.AreEqual(DateTime.Parse("1/1/1900 12:00:00 AM"), repo.getLastReocrd().dateModified);
            Assert.AreEqual(200, repo.getLastReocrd().amount);
            Assert.AreEqual("123", repo.getLastReocrd().code.Trim());
            TransactionDTO found = repo.getLastReocrd();
            //TEST UPDATE
            TransactionDTO update = new TransactionDTO.TransactionBuilder()
                .copy(repo.getLastReocrd())
                .buildCode("444")
                .build();
            repo.update(update);
            Assert.AreEqual("444", repo.getLastReocrd().code.Trim());
            Assert.AreEqual(200, repo.getLastReocrd().amount);
           // Assert.AreEqual(update.dateModified, repo.getLastReocrd().dateModified);

            repo.delete(found.id);
            Assert.IsNull(repo.findByID(found.id));
        }
    }
}
