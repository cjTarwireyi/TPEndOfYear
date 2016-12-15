using BusineesLogic.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.factories
{
    public class ReportFactory
    {
        public static ReportDTO createReport(List<string> reportDetails)
        {
            return new ReportDTO.ReportBuilder()
                        .buildReportName(reportDetails[0])
                        .buildreportContent(reportDetails[1])
                        .buildDateGenerated(DateTime.Now)
                        .build();
        }
    }
}
