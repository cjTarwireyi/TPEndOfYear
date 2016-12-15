using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.domain
{
    public class DepartmentDTO
    {
        public int departmentNumber {get;set;}
        public string departmentName  {get;set;}
        public string departmentDescription { get; set; }

        private DepartmentDTO() { }

        public DepartmentDTO(DepartmentBuilder department)
        {
            this.departmentNumber = department.departmentNumber;
            this.departmentName = department.departmentName;
            this.departmentDescription = department.departmentDescription;
        }

        public class DepartmentBuilder
        {
            public int departmentNumber;
            public string departmentName;
            public string departmentDescription;

            public DepartmentBuilder buildNumber(int departmentNumber)
            {
                this.departmentNumber = departmentNumber;
                return this;
            }

            public DepartmentBuilder buildName(string departmentName)
            {
                this.departmentName = departmentName;
                return this;
            }


            public DepartmentBuilder buildDescription(string departmentDescription)
            {
                this.departmentDescription = departmentDescription;
                return this;
            }


            public DepartmentBuilder copy(DepartmentDTO department)
            {
                this.departmentNumber = department.departmentNumber;
                this.departmentName = department.departmentName;
                this.departmentDescription = department.departmentDescription;
                return this;
            }

            public DepartmentDTO build()
            {
                return new DepartmentDTO(this);
            }
        }

    }
}
