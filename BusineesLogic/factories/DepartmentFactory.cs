using BusineesLogic.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.factories
{
    public class DepartmentFactory
    {
        public static DepartmentDTO createDepartment(List<string> departmentDetails)
        {
            return new DepartmentDTO.DepartmentBuilder()
                       .buildName(departmentDetails[0])
                       .buildDescription(departmentDetails[1])
                       .build();
        }
    }
}
