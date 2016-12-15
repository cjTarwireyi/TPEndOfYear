using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BusineesLogic.domain;
using BusineesLogic.factories;

namespace UnitTests.factories
{
    [TestClass]
    public class TestReport
    {
        [TestMethod]
        public void testCreateReport()
        {
            List<string> reportDetails = new List<string>();
            reportDetails.Add("PRODUCT DETAILS");
            reportDetails.Add("LIST ALL PRODUCTS");
            reportDetails.Add(DateTime.Now.ToString());

            ReportDTO report = ReportFactory.createReport(reportDetails);
            Assert.AreEqual(report.reportName, "PRODUCT DETAILS");
        }

        [TestMethod]
        public void testUpdateReport()
        {
            List<string> reportDetails = new List<string>();
            reportDetails.Add("PRODUCT DETAILS");
            reportDetails.Add("LIST ALL PRODUCTS");
            reportDetails.Add(DateTime.Now.ToString());

            ReportDTO report = ReportFactory.createReport(reportDetails);
            ReportDTO updateReport = new ReportDTO.ReportBuilder()
                                            .copy(report)
                                            .buildReportName("MOST PRODUCTS SOLD")
                                            .build();
            Assert.AreNotEqual(report.reportName,updateReport.reportName);
            Assert.AreEqual(report.reportName, "PRODUCT DETAILS");
        }
    }
}
