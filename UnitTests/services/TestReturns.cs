using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.domain;
using BusineesLogic.services;
using System.Collections.Generic;
using BusineesLogic.factories;

namespace UnitTests.services
{
    [TestClass]
    public class TestReturns
    {
        private ReturnDTO result;
        private ReturnDAO service = new ReturnDAO();
        /*RETURNS CAN ONLY BE RETURNED IT CAN NOT BE UPDATED OR DELETED IT IS USED FOR GERATING PURPOSES*/
        [TestMethod]
        public void testInsertUpdateDeleteReturn()
        {
            List<int> reportDetails = new List<int>();
            reportDetails.Add(1);
            reportDetails.Add(138);
            reportDetails.Add(1);
            reportDetails.Add(1);
            ReturnDTO returns = ReturnFactory.createReturnRecord(reportDetails);

            //insert
            service.save(returns);
            result = service.getLastReocrd();
            Assert.IsNotNull(result);

        }
    }
}
