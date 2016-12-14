using BusineesLogic.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.factories
{
    class ReportTypeFactory
    {
        public static ReportTypeDTO getReportType(List<string> type)
        {
            return new ReportTypeDTO.ReportTypeBuilder()
                        .buildReportCategory(type[0])
                        .buildPeroidLength(type[1])
                        .build();
        }
    }
}
