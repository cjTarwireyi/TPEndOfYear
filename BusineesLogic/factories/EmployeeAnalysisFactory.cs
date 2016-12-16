using BusineesLogic.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.factories
{
    public class EmployeeAnalysisFactory
    {
        public static EmployeeAnalysisDTO createAnalysis(int employeeID,int daysLate,int daysWorked,int monthlySales)
        {
            return new EmployeeAnalysisDTO.EmployeeAnalysisBuilder()
                                            .buildEmpID(employeeID)
                                            .buildDaysLate(daysLate)
                                            .buildDaysWorkedMonth(daysWorked)
                                            .buildSalesMade(monthlySales)
                                            .build();
        }

    }
}
