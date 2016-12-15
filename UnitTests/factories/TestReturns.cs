using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.domain;
using BusineesLogic.factories;
using System.Collections.Generic;

namespace UnitTests.factories
{
    [TestClass]
    public class TestReturns
    {
        [TestMethod]
        public void testCreateReturns()
        {
            List<int> reportDetails = new List<int>();
            reportDetails.Add(112);
            reportDetails.Add(10);
            reportDetails.Add(15);
            reportDetails.Add(11);
            ReturnDTO returns = ReturnFactory.createReturnRecord(reportDetails);
            Assert.AreEqual(returns.customerID,112);

        }

        [TestMethod]
        public void testUpdateReturns()
        {
            List<int> reportDetails = new List<int>();
            reportDetails.Add(112);
            reportDetails.Add(10);
            reportDetails.Add(15);
            reportDetails.Add(11);
            ReturnDTO returns = ReturnFactory.createReturnRecord(reportDetails);
            ReturnDTO updateReturn = new ReturnDTO.ReturnBuilder()
                                        .copy(returns)
                                        .customerNumber(113)
                                        .build();
            Assert.AreNotEqual(returns.customerID, updateReturn.customerID);

        }
    }
}
