using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BusineesLogic.factories;

namespace UnitTests.factories.employee
{
    [TestClass]
    public class TestEmployee
    {
        [TestMethod]
        public void testCreateEmployee()
        {
            List<string> employeeDetails = new List<string>();
            employeeDetails.Add("Shireen");
            employeeDetails.Add("Wilkinson");
            employeeDetails.Add("0783588370");
            employeeDetails.Add("Sparrow");
            employeeDetails.Add("Rocklands");
            employeeDetails.Add("7798");


            EmployeeDTO employee = EmployeeFactory.createEmployee(employeeDetails);

            Assert.AreEqual(employee.employeeName, "Shireen");
            Assert.AreEqual(employee.employeeCellNumber, "0783588370");
            Assert.AreEqual(employee.employeeStreetName, "Sparrow");
            Assert.AreEqual(employee.employeeSuburb, "Rocklands");
            Assert.AreEqual(employee.employeePostalCode, "7798");
        }


        public void testUpdateEmployee()
        {
            List<string> employeeDetails = new List<string>();
            employeeDetails.Add("Shireen");
            employeeDetails.Add("Wilkinson");
            employeeDetails.Add("0783588370");
            employeeDetails.Add("Sparrow");
            employeeDetails.Add("Rocklands");
            employeeDetails.Add("7798");


            EmployeeDTO employee = EmployeeFactory.createEmployee(employeeDetails);
            EmployeeDTO updateEmployee = new EmployeeDTO.EmployeeBuilder()
                    .copy(employee)
                    .empName("Kaashiefa")
                    .build();
            Assert.AreEqual(employee.employeeSurname, updateEmployee.employeeSurname);
            Assert.AreNotEqual(employee.employeeName, updateEmployee.employeeName);
        }
    }
}
