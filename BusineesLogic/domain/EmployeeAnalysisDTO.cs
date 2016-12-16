using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.domain
{
    public class EmployeeAnalysisDTO
    {
        public int employeeID { get; set; }
        public int daysLate { get; set; }
        public int daysWorkedForMotnh { get; set; }
        public int SalesMadeForMonth { get; set; }
        private EmployeeAnalysisDTO() { }

        public EmployeeAnalysisDTO(EmployeeAnalysisBuilder analysis)
        {
            this.employeeID = analysis.employeeID;
            this.daysLate = analysis.daysLate;
            this.daysWorkedForMotnh = analysis.daysWorkedForMotnh;
            this.SalesMadeForMonth = analysis.SalesMadeForMonth;
        }
        public class EmployeeAnalysisBuilder
        {
            public int employeeID;
            public int daysLate;
            public int daysWorkedForMotnh;
            public int SalesMadeForMonth;

            public EmployeeAnalysisBuilder buildEmpID(int employeeID)
            {
                this.employeeID = employeeID;
                return this;
            }

            public EmployeeAnalysisBuilder buildDaysLate(int daysLate)
            {
                this.daysLate = daysLate;
                return this;
            }

            public EmployeeAnalysisBuilder buildDaysWorkedMonth(int daysWorkedForMotnh)
            {
                this.daysWorkedForMotnh = daysWorkedForMotnh;
                return this;
            }

            public EmployeeAnalysisBuilder buildSalesMade(int SalesMadeForMonth)
            {
                this.SalesMadeForMonth = SalesMadeForMonth;
                return this;
            }


            public EmployeeAnalysisBuilder copy(EmployeeAnalysisDTO analysis)
            {
                this.employeeID = analysis.employeeID;
                this.daysLate = analysis.daysLate;
                this.daysWorkedForMotnh = analysis.daysWorkedForMotnh;
                this.SalesMadeForMonth = analysis.SalesMadeForMonth;
                return this;
            }

            public EmployeeAnalysisDTO build()
            {
                return new EmployeeAnalysisDTO(this);
            }
        }
    }
}
