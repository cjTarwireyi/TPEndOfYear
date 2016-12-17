using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BusineesLogic.factories;

namespace UnitTests.services
{
    [TestClass]
    public class EmployeeTest
    {
        private EmployeeDTO result;
        private EmployeeDAO service = new EmployeeDAO();
        [TestMethod]
        public void testInsertUpdateDeleteEmployee()
        {
            List<string> employeeDetails = new List<string>();
            employeeDetails.Add("Shireen");
            employeeDetails.Add("Wilkinson");
            employeeDetails.Add("0783588370");
            employeeDetails.Add("Sparrow");
            employeeDetails.Add("Rocklands");
            employeeDetails.Add("7798");
            EmployeeDTO employee = EmployeeFactory.createEmployee(employeeDetails);

            //insert
            service.save(employee);
            result = service.getLastRecrd();
            int id = result.employeeNumber;
            Assert.IsNotNull(result);

            //updating
            EmployeeDTO updateEmployee = new EmployeeDTO.EmployeeBuilder()
                                                        .copy(result)
                                                        .empName("Siraaj")
                                                        .build();

            service.updateEmployee(updateEmployee);
            result = service.getEmployee(id);
            // Assert.AreEqual(result.employeeName.Trim(),"Siraaj");


            //delete
            service.delete(id.ToString());
            result = service.getEmployee(id);
            Assert.IsNull(result);
        }
    }
}
