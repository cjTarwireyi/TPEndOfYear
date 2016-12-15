using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.domain
{
    public class ReportDTO
    {
        public string reportName { get; set; }
        public DateTime dateGenerated { get; set; }
        public string reportContent { get; set; }

        private ReportDTO() { }

        public ReportDTO(ReportBuilder report)
        {
            this.reportName = report.reportName;
            this.dateGenerated = report.dateGenerated;
            this.reportContent = report.reportContent;

        }

        public class ReportBuilder
        {
            public string reportName;
            public DateTime dateGenerated;
            public string reportContent;

            public ReportBuilder buildReportName(string reportName)
            {
                this.reportName = reportName;
                return this;
            }

            public ReportBuilder buildDateGenerated(DateTime dateGenerated)
            {
                this.dateGenerated = dateGenerated;
                return this;
            }

            public ReportBuilder buildreportContent(string reportContent)
            {
                this.reportContent = reportContent;
                return this;
            }


            public ReportBuilder copy(ReportDTO report)
            {
                this.reportName = report.reportName;
                this.dateGenerated = report.dateGenerated;
                this.reportContent = report.reportContent;
                return this;
            }


            public ReportDTO build()
            {
                return new ReportDTO(this);
            }

        }
    }
}
