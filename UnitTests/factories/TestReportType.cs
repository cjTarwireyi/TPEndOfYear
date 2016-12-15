using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusineesLogic.domain;
using BusineesLogic.factories;
using System.Collections.Generic;

namespace UnitTests.factories
{
    [TestClass]
    public class TestReportType
    {
        [TestMethod]
        public void testCreateReportType()
        {
            List<string> type = new List<string>();
            type.Add("Customer");
            type.Add("Year");
            ReportTypeDTO reportype = ReportTypeFactory.getReportType(type);
            Assert.AreEqual(reportype.reportCategory, "Customer");
        }

        [TestMethod]
        public void testUpdateReportType()
        {
            List<string> type = new List<string>();
            type.Add("Customer");
            type.Add("Year");
            ReportTypeDTO reportype = ReportTypeFactory.getReportType(type);
            ReportTypeDTO updateReport = new ReportTypeDTO.ReportTypeBuilder()
                                            .copy(reportype)
                                            .buildReportCategory("PRODUCTS")
                                            .build();


            Assert.AreNotEqual(reportype.reportCategory, updateReport.reportCategory);
        }
    }
}
