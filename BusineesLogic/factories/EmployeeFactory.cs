using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.factories
{
    class EmployeeFactory
    {
        public static EmployeeDTO createEmployee(List<string> employeeDetails)
        {
            return new EmployeeDTO.EmployeeBuilder()
            .empName(employeeDetails[0])
            .empSurname(employeeDetails[1])
            .empCellNumber(employeeDetails[2])
            .empDateHired(employeeDetails[3])
            .empAddress(employeeDetails[4], employeeDetails[5], employeeDetails[6])
            .build();

        }
    }
}
