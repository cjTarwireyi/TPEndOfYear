using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.factories.employee
{
    [TestClass]
    public class TestEmployee
    {
        [TestMethod]
        public void createEmployee()
        {
            EmployeeDTO employee = new EmployeeDTO.EmployeeBuilder()
            .empName("Kashiefa")
            .empSurname("Cottle")
            .empCellNumber("0783236146")
            .empAddress("SpitzWay", "Strandfontein", "7798")
            .build();

            Assert.AreEqual(employee.employeeName, "Kashiefa");
            Assert.AreEqual(employee.employeeCellNumber, "0783236146");
            Assert.AreEqual(employee.employeeStreetName, "SpitzWay");
            Assert.AreEqual(employee.employeeSuburb, "Strandfontein");
            Assert.AreEqual(employee.employeePostalCode, "7798");
        }
    }
}
