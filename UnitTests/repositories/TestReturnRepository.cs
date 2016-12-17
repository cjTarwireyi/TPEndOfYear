using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.domain;
using BusineesLogic.repositories.Impl;
using System.Collections.Generic;
using BusineesLogic.factories;

namespace UnitTests.repositories
{
    [TestClass]
    public class TestReturnRepository
    {
        /*RETURNS CAN ONLY BE RETURNED IT CAN NOT BE UPDATED OR DELETED IT IS USED FOR GERATING PURPOSES*/

        private ReturnDTO result;
        private ReturnRepositoryImpl repo = new ReturnRepositoryImpl();

        [TestMethod]
        public void testInsertReturns() 
        {
            List<int> reportDetails = new List<int>();
            reportDetails.Add(1);
            reportDetails.Add(138);
            reportDetails.Add(1);
            reportDetails.Add(1);
            ReturnDTO returns = ReturnFactory.createReturnRecord(reportDetails);

            //insert
            repo.save(returns);
            result = repo.getLastReocrd();
            Assert.IsNotNull(result);


        }
    }
}
