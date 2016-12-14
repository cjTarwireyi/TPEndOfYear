using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.domain
{
    class ReportTypeDTO
    {
        string reportCategory { get; set; }
        string peroidForStats { get; set; }

        private ReportTypeDTO() { }

        public ReportTypeDTO (ReportTypeBuilder reportType)
        {
            this.reportCategory = reportType.reportCategory;
            this.peroidForStats = reportType.peroidForStats;
        }

        public class ReportTypeBuilder
        {
            public string reportCategory;
            public string peroidForStats;

            public ReportTypeBuilder buildReportCategory(string reportCategory)
            {
                this.reportCategory = reportCategory;
                return this;
            }

            public ReportTypeBuilder buildPeroidLength(string peroidForStats)
            {
                this.peroidForStats = peroidForStats;
                return this;
            }

            public ReportTypeBuilder copy(ReportTypeDTO reportType)
            {
                this.reportCategory = reportType.reportCategory;
                this.peroidForStats = reportType.peroidForStats;
                return this;
            }


            public ReportTypeDTO build()
            {
                return new ReportTypeDTO(this);
            }
        }
    }
}
