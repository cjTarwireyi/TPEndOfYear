using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.domain;
using BusineesLogic.factories;

namespace UnitTests.factories
{
    [TestClass]
    public class TestEmployeeAnalysis
    {
        [TestMethod]
        public void testCreateEmployeeAnalysis()
        {
            EmployeeAnalysisDTO analysis = EmployeeAnalysisFactory.createAnalysis(101,12,23,15);
            Assert.IsNotNull(analysis);

        }

        [TestMethod]
        public void testUpdateEmployeeAnalysis()
        {
            EmployeeAnalysisDTO analysis = EmployeeAnalysisFactory.createAnalysis(101, 12, 23, 15);
            EmployeeAnalysisDTO update = new EmployeeAnalysisDTO.EmployeeAnalysisBuilder()
                                                                   .copy(analysis)
                                                                    .buildDaysLate(10)
                                                                    .build();

            Assert.AreEqual(analysis.employeeID, analysis.employeeID);
            Assert.AreNotEqual(analysis.daysLate, analysis.daysLate);

        }
    }
}
