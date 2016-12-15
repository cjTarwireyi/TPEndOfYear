using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.factories
{
    public class EmployeeFactory
    {
        public static EmployeeDTO createEmployee(List<string> employeeDetails)
        {
            return new EmployeeDTO.EmployeeBuilder()
            .empName(employeeDetails[0])
            .empSurname(employeeDetails[1])
            .empCellNumber(employeeDetails[2])
            .empDateHired(DateTime.Now.ToString())
            .empAddress(employeeDetails[3], employeeDetails[4], employeeDetails[5])
            .build();

        }
    }
}
